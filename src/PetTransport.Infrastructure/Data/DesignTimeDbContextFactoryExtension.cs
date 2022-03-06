using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace PetTransport.Infrastructure.Data;

public class DesignTimeDbContextFactoryExtension : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseSqlite("DataSource=app.db;Cache=Shared");

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}