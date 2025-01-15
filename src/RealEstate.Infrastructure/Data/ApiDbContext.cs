using Microsoft.EntityFrameworkCore;
using RealEstate.Domain.Entities.Security.Jwt;

namespace RealEstate.Infrastructure.Data;

public class ApiDbContext(DbContextOptions<ApiDbContext> options) : DbContext(options)
{
    public DbSet<User> TokenUser { get; set; }
    //public DbSet<User> User { get; set; }
    //public DbSet<Country> Country { get; set; }
    //public DbSet<City> City { get; set; }
    //public DbSet<Department> Department { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApiDbContext).Assembly);
        //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}