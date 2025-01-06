namespace DonatorAPI.Data.Configurations;

using DonatorAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class PurchaseConfiguration : IEntityTypeConfiguration<Purchase>
{
    public void Configure(EntityTypeBuilder<Purchase> builder)
    {
        builder.ToTable("purchase_history");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .HasColumnName("purchase_id");

        builder.Property(p => p.Auth)
            .HasColumnName("user_auth")
            .IsRequired();

        builder.Property(p => p.Price)
            .HasColumnName("price");

        builder.Property(p => p.PurchaseDate)
            .HasColumnName("purchase_time");

        builder.HasOne(p => p.UserInfo)
            .WithMany(u => u.PurchaseHistories)
            .HasForeignKey(p => p.Auth);
    }
}
