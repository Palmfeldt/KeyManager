using KeyManager.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KeyManager.Persistence.Configurations;

public class KeyConfiguration : IEntityTypeConfiguration<Key>
{
    public void Configure(EntityTypeBuilder<Key> builder)
    {
        builder.HasKey(k => k.Id);
        builder.Property(k => k.Id)
            .ValueGeneratedOnAdd();

        builder.Property(k => k.KeyIdentifier)
            .IsRequired(false)
            .HasMaxLength(50);
        builder.Property(k => k.Brand)
            .IsRequired(true);
        builder.Property(k => k.IsLost)
            .IsRequired(true);
    }
}