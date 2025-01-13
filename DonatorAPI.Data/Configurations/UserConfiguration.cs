namespace DonatorAPI.Data.Configurations;

using DonatorAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .HasKey(u => u.Id);

        builder
            .Property(u => u.SteamdId64)
            .IsRequired();

        builder
            .Property(u => u.DateCreated)
            .IsRequired();

        builder
            .HasMany(u => u.Purchases)
            .WithOne()
            .HasForeignKey(p => p.UserId);
    }
}
