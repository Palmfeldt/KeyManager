using KeyManager.Persistence.DatabaseModels;
using Microsoft.EntityFrameworkCore;

namespace KeyManager.Persistence.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Key> Keys { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Ensure unique constraint on KeyIdentifier
            modelBuilder.Entity<Key>()
                .HasIndex(k => k.KeyIdentifier)
                .IsUnique();

            // Define Foreign Key Relationships
            modelBuilder.Entity<Address>()
                .HasOne(ua => ua.User)
                .WithMany()
                .HasForeignKey(ua => ua.Id)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Address>()
                .HasOne(ua => ua.Key)
                .WithMany()
                .HasForeignKey(ua => ua.Id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
