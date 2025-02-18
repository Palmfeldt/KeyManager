using KeyManager.Models;
using Microsoft.EntityFrameworkCore;

namespace KeyManager.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Key> Keys { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Ensure unique constraint on KeyIdentifier
            modelBuilder.Entity<Key>()
                .HasIndex(k => k.KeyIdentifier)
                .IsUnique();

            // Define Foreign Key Relationships
            modelBuilder.Entity<UserAddress>()
                .HasOne(ua => ua.User)
                .WithMany()
                .HasForeignKey(ua => ua.Id);

            modelBuilder.Entity<UserAddress>()
                .HasOne(ua => ua.Key)
                .WithMany()
                .HasForeignKey(ua => ua.Id);
        }
    }
}
