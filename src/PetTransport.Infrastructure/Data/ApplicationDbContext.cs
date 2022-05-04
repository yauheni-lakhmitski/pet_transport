﻿using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PetTransport.Domain;
using PetTransport.Domain.Entities;

namespace PetTransport.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public DbSet<Trip> Trips { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<Transportation> Transportations { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Application> Applications { get; set; }
    public DbSet<ApplicationItem> ApplicationItems { get; set; }
    public DbSet<Ride> Rides { get; set; }


    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        Database.Migrate();
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.UseEntityTypeConfiguration();
        
        builder.Entity<UserTrip>()
            .HasKey(t => new { t.UserId, t.TripId });

        builder.Entity<UserTrip>()
            .HasOne(pt => pt.Trip)
            .WithMany(p => p.UserTrips)
            .HasForeignKey(pt => pt.TripId);

        builder.Entity<UserTrip>()
            .HasOne(pt => pt.User)
            .WithMany(t => t.UserTrips)
            .HasForeignKey(pt => pt.UserId);
        

        
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}