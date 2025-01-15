using Microsoft.EntityFrameworkCore;
using RealEstate.Domain.Entities.Controller;
using RealEstate.Domain.Entities.Security.Jwt;

namespace RealEstate.Infrastructure.Data;

public class ApiDbContext(DbContextOptions<ApiDbContext> options) : DbContext(options)
{
    public DbSet<User> TokenUser { get; set; }
    public DbSet<Owner> Owner { get; set; }
    public DbSet<PropertyImage> PropertyImages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApiDbContext).Assembly);
    }
}