using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PetTransport.Domain;
using PetTransport.Domain.Entities;

namespace PetTransport.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Application> Applications { get; set; }
    public DbSet<ApplicationItem> ApplicationItems { get; set; }
    public DbSet<Ride> Rides { get; set; }
    public DbSet<RideDetail> RideDetails { get; set; }
    public DbSet<AnimalType> AnimalTypes { get; set; }


    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        Database.Migrate();
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.UseEntityTypeConfiguration();
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}