using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAppBootstrap.Domain.Users;

namespace WebAppBootstrap.Infrastructure.Configurations;

public class InvoiceAddressConfiguration : IEntityTypeConfiguration<InvoiceAddress>
{
    public void Configure(EntityTypeBuilder<InvoiceAddress> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.User)
            .WithOne(x => x.InvoiceAddress)
            .HasForeignKey<InvoiceAddress>(x => x.UserId)
            .IsRequired();
    }
}