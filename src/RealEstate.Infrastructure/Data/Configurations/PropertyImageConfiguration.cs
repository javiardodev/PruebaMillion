using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstate.Domain.Entities.Controller;

namespace RealEstate.Infrastructure.Data.Configurations;

public class PropertyImageConfiguration
{
    public void Configure(EntityTypeBuilder<PropertyImage> builder)
    {
        builder.ToTable(nameof(PropertyImage))
            .HasQueryFilter(pi => pi.Enabled)
            .HasOne(pi => pi.Property)
            .WithMany(p => p.PropertyImages)
            .HasForeignKey(pi => pi.IdProperty);

        builder
            .Property(pi => pi.Id)
            .IsRequired()
            .HasColumnName("IdPropertyImage");

        builder
            .Property(pi => pi.File)
            .HasColumnName("File");

        builder
            .Property(pi => pi.Enabled)
            .HasColumnName("Enabled")
            .HasDefaultValue(true);

        builder
            .Property(pi => pi.IdProperty)
            .IsRequired()
            .HasColumnName("IdProperty");

        builder
            .Property(pi => pi.CreatedAt)
            .IsRequired()
            .HasColumnName("CreatedAt")
            .HasDefaultValue("1900-01-01 00:00:00");

        builder
            .Property(pi => pi.UpdatedAt)
            .HasColumnName("UpdatedAt")
            .HasDefaultValue(null);
    }
}