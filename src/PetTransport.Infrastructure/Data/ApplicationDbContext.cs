﻿using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PetTransport.Domain;

namespace PetTransport.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public DbSet<Trip> Trips { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<InviteCode> InviteCodes { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<TaskList> TaskLists { get; set; }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
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