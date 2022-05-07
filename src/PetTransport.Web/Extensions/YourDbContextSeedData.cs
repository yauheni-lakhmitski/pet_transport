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

    public async void SeedDatabase()
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
            await roleStore.CreateAsync(new IdentityRole {Name = "Водитель", NormalizedName = "ВОДИТЕЛЬ"});
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

        if (!_context.AnimalTypes.Any())
        {
            _context.AnimalTypes.Add(new AnimalType(){Id = Guid.Parse("63facdd6-3d19-446d-bd27-e5b3ded7b837"), Name = "Собака"});
            _context.AnimalTypes.Add(new AnimalType(){Id = Guid.Parse("f198f845-a7ba-4d43-8d90-55a0532576e6"), Name = "Кот"});
            _context.AnimalTypes.Add(new AnimalType(){Id = Guid.Parse("cd5ae4ff-d662-4787-9a57-e6e272f2e7eb"), Name = "Попугай"});
            _context.AnimalTypes.Add(new AnimalType(){Id = Guid.Parse("c02ce9f4-b257-41b5-9a43-df416747204b"), Name = "Рептилия"});
            _context.AnimalTypes.Add(new AnimalType(){Id = Guid.Parse("ffd45966-baaa-4dc7-91f5-2208990aedf7"), Name = "Крупный рогатый скот"});
        }
        

        await _context.SaveChangesAsync();
    }
}