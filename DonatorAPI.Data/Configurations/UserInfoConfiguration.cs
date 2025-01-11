namespace DonatorAPI.Data.Configurations;

using DonatorAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserInfoConfiguration : IEntityTypeConfiguration<UserInfo>
{
    public void Configure(EntityTypeBuilder<UserInfo> builder)
    {
        builder.ToTable("userinfo");

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id)
            .HasColumnName("user_id")
            .IsRequired();

        builder.Property(u => u.Auth)
            .HasColumnName("user_auth")
            .IsRequired();

        builder.Property(u => u.DonateTier)
            .HasColumnName("donate_tier")
            .IsRequired();

        builder.Property(u => u.ExpireTime)
            .HasColumnName("expire_time");

        builder.HasMany(u => u.PurchaseHistories)
            .WithOne(p => p.UserInfo)
            .HasForeignKey(p => p.Auth)
            .HasPrincipalKey(u => u.Auth);
    }
}
