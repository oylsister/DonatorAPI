using DonatorAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DonatorAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<UserInfo> Users { get; set; }
        public DbSet<PurchaseHistory> PurchaseHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserInfo>()
                .HasMany(u => u.PurchaseHistories)
                .WithOne(ph => ph.UserInfo)
                .HasForeignKey(ph => ph.Auth)
                .HasPrincipalKey(u => u.Auth);

            modelBuilder.Entity<PurchaseHistory>()
                .HasOne(ph => ph.UserInfo)
                .WithMany(u => u.PurchaseHistories)
                .HasForeignKey(ph => ph.Auth)
                .HasPrincipalKey(u => u.Auth);

            base.OnModelCreating(modelBuilder); 
        }
    }
}
