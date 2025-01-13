using DonatorAPI.Data.Configurations;
using DonatorAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DonatorAPI.Data;

public class DonatorDataContext(
    DbContextOptions<DonatorDataContext> options
    ) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Purchase> PurchaseHistories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new PurchaseConfiguration());
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new ProductCategoryConfiguration());
    }
}
