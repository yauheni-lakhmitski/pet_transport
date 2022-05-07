using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetTransport.Domain.Entities;

namespace PetTransport.Infrastructure.EntityConfigurations;

public class RideConfiguration : IEntityTypeConfiguration<Ride>
{
    public void Configure(EntityTypeBuilder<Ride> builder)
    {
        builder.ToTable("Rides");

        builder.HasMany(x => x.Applications)
            .WithOne(x => x.Ride)
            .OnDelete(DeleteBehavior.SetNull);
    }   
}