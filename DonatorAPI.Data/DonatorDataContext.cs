using DonatorAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DonatorAPI.Data;

public class DonatorDataContext(
    DbContextOptions<DonatorDataContext> options
    ) : DbContext(options)
{
    public DbSet<UserInfo> Users { get; set; }

    public DbSet<Purchase> PurchaseHistories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserInfo>()
            .HasMany(u => u.PurchaseHistories)
            .WithOne(ph => ph.UserInfo)
            .HasForeignKey(ph => ph.Auth)
            .HasPrincipalKey(u => u.Auth);

        modelBuilder.Entity<Purchase>()
            .HasOne(ph => ph.UserInfo)
            .WithMany(u => u.PurchaseHistories)
            .HasForeignKey(ph => ph.Auth)
            .HasPrincipalKey(u => u.Auth);

        base.OnModelCreating(modelBuilder);
    }
}
