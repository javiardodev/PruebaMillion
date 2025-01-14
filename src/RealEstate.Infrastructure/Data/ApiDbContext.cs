using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Infrastructure.Data;

public class ApiDbContext(DbContextOptions<ApiDbContext> options) : DbContext(options)
{
    //public DbSet<TokenUser> TokenUser { get; set; }
    //public DbSet<User> User { get; set; }
    //public DbSet<Country> Country { get; set; }
    //public DbSet<City> City { get; set; }
    //public DbSet<Department> Department { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<TokenUser>().HasNoKey();
    }
}