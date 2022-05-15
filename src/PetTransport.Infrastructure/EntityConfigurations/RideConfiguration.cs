using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetTransport.Domain.Entities;

namespace PetTransport.Infrastructure.EntityConfigurations;

// public class RideConfiguration : IEntityTypeConfiguration<Ride>
// {
//     public void Configure(EntityTypeBuilder<Ride> builder)
//     {
//         builder.ToTable("Rides");
//
//         builder.HasMany(x => x.Applications)
//             .WithOne(x => x.Ride)
//             .HasForeignKey(x=>x.RideId)
//             .OnDelete(DeleteBehavior.Cascade);
//         
//     }   
// }
//
// public class ApplicationConfiguration : IEntityTypeConfiguration<Application>
// {
//     public void Configure(EntityTypeBuilder<Application> builder)
//     {
//
//         builder.HasOne(x => x.Ride)
//             .WithMany(x => x.Applications)
//             .OnDelete(DeleteBehavior.Cascade);
//     }   
// }