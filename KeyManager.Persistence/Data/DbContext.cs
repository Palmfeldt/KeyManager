using KeyManager.Domain.Models;
using KeyManager.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace KeyManager.Persistence.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Resident> Residents { get; set; }
    public DbSet<Key> Keys { get; set; }
    public DbSet<Property> Properties { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        // Define Foreign Key Relationships
        modelBuilder.Entity<Property>()
            .HasOne(ua => ua.Resident)
            .WithMany(r => r.Properties)
            .HasForeignKey(ua => ua.ResidentId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Cascade);

        // One key can only be associated with one property, but a property can have many keys
        modelBuilder.Entity<Property>()
            .HasMany(ua => ua.Keys)
            .WithOne(k => k.Property)
            .HasForeignKey(k => k.PropertyId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Cascade);

        // A key can be associated with one resident, but a resident can have many keys
        modelBuilder.Entity<Resident>()
            .HasMany(r => r.Keys)
            .WithOne(k => k.Resident)
            .HasForeignKey(k => k.ResidentId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.NoAction);

        // A key can be associated with one property, but a property can have many keys
        modelBuilder.Entity<Key>()
            .HasOne(k => k.Property)
            .WithMany(p => p.Keys)
            .HasForeignKey(k => k.PropertyId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.ApplyConfiguration(new KeyConfiguration());
        modelBuilder.ApplyConfiguration(new ResidentConfiguration());
        modelBuilder.ApplyConfiguration(new PropertyConfiguration());

    }
}
