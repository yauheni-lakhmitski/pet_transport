using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using PetTransport.Domain.Entities;
using PetTransport.Infrastructure.Data;

namespace PetTransport.Web.Extensions;

public class ContextSeedData
{
    private ApplicationDbContext _context;

    public ContextSeedData(ApplicationDbContext context)
    {
        _context = context;
    }

    public async void SeedAdminUser()
    {
        var user = new User
        {
            FirstName = "Admin",
            LastName = "Admin",
            UserName = "admin@admin.com",
            NormalizedUserName = "ADMIN@ADMIN.COM",
            Email = "admin@admin.com",
            NormalizedEmail = "ADMIN@ADMIN.COM",
            EmailConfirmed = true,
            LockoutEnabled = false,
            SecurityStamp = Guid.NewGuid().ToString(),
            ImageUrl = "medium_male_default.png"
        };

        var roleStore = new RoleStore<IdentityRole>(_context);

        if (!_context.Roles.Any())
        {
            await roleStore.CreateAsync(new IdentityRole {Name = "Менеджер", NormalizedName = "МЕНЕДЖЕР"});
            await roleStore.CreateAsync(new IdentityRole {Name = "Водитель", NormalizedName = "Водитель"});
        }

        if (!_context.Users.Any(u => u.UserName == user.UserName))
        {
            var password = new PasswordHasher<User>();
            var hashed = password.HashPassword(user, "admin");
            user.PasswordHash = hashed;
            var userStore = new UserStore<User>(_context);
            await userStore.CreateAsync(user);
            await userStore.AddToRoleAsync(user, "МЕНЕДЖЕР");
        }

        await _context.SaveChangesAsync();
    }
}