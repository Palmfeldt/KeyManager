using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using KeyManager.Domain.Models;

namespace KeyManager.Persistence.Configurations;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Id)
            .ValueGeneratedOnAdd();

        builder.Property(a => a.LeaseStart)
            .IsRequired();

        builder.Property(a => a.LeaseEnd);

        builder.Property(a => a.FullAddress)
            .IsRequired()
            .HasMaxLength(50);

        builder.HasOne(a => a.User);
        builder.HasOne(a => a.Key);
    }
}