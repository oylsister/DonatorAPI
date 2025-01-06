using DonatorAPI.Data.Configurations;
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
        modelBuilder.ApplyConfiguration(new UserInfoConfiguration());
        modelBuilder.ApplyConfiguration(new PurchaseConfiguration());
    }
}
