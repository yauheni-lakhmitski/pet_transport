using System.Net;
using System.Net.Security;
using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PetTransport.Domain.Entities;
using PetTransport.Infrastructure.Data;
using PetTransport.Web;
using PetTransport.Web.Attributes;
using PetTransport.Web.Behaviours;
using PetTransport.Web.Chat;
using PetTransport.Web.Extensions;
using PetTransport.Web.Models;
using Radzen;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<TokenProvider>();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<ContextMenuService>();
builder.Services.AddTransient<ContextSeedData>();
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehavior<,>));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CommandHandlingBehavior<,>));



// Add services to the container.
// var sqlServer = builder.Configuration.GetConnectionString("DefaultConnection");
var connectionString = builder.Configuration.GetConnectionString("SqlLiteDefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString)
    // options.UseNpgsql(postgresconnectionString)
    
    );



builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
builder.Services.AddDefaultIdentity<User>(options =>
{
    options.User.RequireUniqueEmail = true;
    //opts.User.AllowedUserNameCharacters = ".@abcdefghijklmnopqrstuvwxyz";
    options.Password.RequiredLength = 5;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireDigit = false;
    options.SignIn.RequireConfirmedAccount = false;
})
    .AddRoles<IdentityRole>()
    .AddDefaultTokenProviders()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews(x=>x.Filters.Add(typeof(ApiExceptionFilterAttribute)))
    .AddFluentValidation();

builder.Services.AddScoped<IUserClaimsPrincipalFactory<User>, AdditionalUserClaimsPrincipalFactory>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetService<ApplicationDbContext>();

    var service = scope.ServiceProvider.GetService<ContextSeedData>();
    service.SeedDatabase();
  

ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, errors) =>
{
    // local dev, just approve all certs
    return true;
   
};
// AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
// // Seed the database.
// app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.MapHub<BlazorChatSampleHub>(BlazorChatSampleHub.HubUrl);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();