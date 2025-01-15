using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstate.Domain.Entities.Security.Jwt;

namespace RealEstate.Infrastructure.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("SecurityUser", "res")
                .HasQueryFilter(u => u.IsActive)
                .HasKey(u => u.Id);

            builder
                .Property(u => u.Id)
                .HasColumnName("IdSecurityUser");

            builder
                .Property(u => u.Username)
                .HasColumnName("Username");

            builder
                .Property(u => u.Password)
                .HasColumnName("Password");

            builder
                .Property(u => u.IsActive)
                .HasColumnName("IsActive")
                .HasDefaultValue(true);

            builder
                .Property(u => u.CreatedAt)
                .HasColumnName("CreatedAt");

            builder
                .Property(u => u.UpdatedAt)
                .HasColumnName("UpdatedAt")
                .HasDefaultValue(null);
        }
    }
}
