using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using KeyManager.Domain.Models;

namespace KeyManager.Persistence.Configurations;

public class KeyConfiguration : IEntityTypeConfiguration<Key>
{
    public void Configure(EntityTypeBuilder<Key> builder)
    {
        builder.HasKey(k => k.Id);
        builder.Property(k => k.Id)
            .ValueGeneratedOnAdd();

        builder.Property(k => k.KeyIdentifier)
            .IsRequired()
            .HasMaxLength(50);
    }
}