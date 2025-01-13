namespace DonatorAPI.Data.Configurations;

using DonatorAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder
            .HasKey(p => p.Id);

        builder
            .Property(p => p.Price)
            .IsRequired();

        builder
            .Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder
            .Property(p => p.Description)
            .HasMaxLength(500);

        builder
            .Property(p => p.DateCreated)
            .IsRequired();

        builder
            .HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId);

        builder
            .HasMany(p => p.Purchases)
            .WithOne(pu => pu.Product)
            .HasForeignKey(pu => pu.ProductId);
    }
}
