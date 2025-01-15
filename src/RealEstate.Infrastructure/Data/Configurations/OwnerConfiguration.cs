using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstate.Domain.Entities.Controller;

namespace RealEstate.Infrastructure.Data.Configurations;

public class OwnerConfiguration : IEntityTypeConfiguration<Owner>
{
    public void Configure(EntityTypeBuilder<Owner> builder)
    {
        builder.ToTable(nameof(Owner), "reo")
            .HasQueryFilter(u => !u.IsDeleted)
            .HasKey(u => u.Id);

        builder
            .Property(o => o.Id)
            .IsRequired()
            .HasColumnName("IdOwner");

        builder
            .Property(o => o.Name)
            .IsRequired()
            .HasColumnName("Name");

        builder
            .Property(o => o.Address)
            .IsRequired()
            .HasColumnName("Address");

        builder
            .Property(o => o.Photo)
            .HasColumnName("Photo");

        builder
            .Property(o => o.Birthday)
            .IsRequired()
            .HasColumnName("Birthday")
            .HasDefaultValue("1900-01-01");

        builder
            .Property(o => o.IsDeleted)
            .IsRequired()
            .HasColumnName("IsDeleted")
            .HasDefaultValue(false);

        builder
            .Property(o => o.CreatedAt)
            .IsRequired()
            .HasColumnName("CreatedAt")
            .HasDefaultValue("1900-01-01 00:00:00");

        builder
            .Property(o => o.UpdatedAt)
            .HasColumnName("UpdatedAt")
            .HasDefaultValue(null);
    }
}
