namespace DonatorAPI.Data.Configurations;

using DonatorAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
{
    public void Configure(EntityTypeBuilder<ProductCategory> builder)
    {
        builder
            .HasKey(pc => pc.Id);

        builder
            .Property(pc => pc.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder
            .Property(pc => pc.Description)
            .HasMaxLength(500);

        builder
            .Property(pc => pc.DateCreated);

        builder
            .HasMany(pc => pc.Products)
            .WithOne(p => p.Category)
            .HasForeignKey(p => p.CategoryId);
    }
}
