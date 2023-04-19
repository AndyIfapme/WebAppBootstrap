using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAppBootstrap.Domain.Items;

namespace WebAppBootstrap.Infrastructure.Configurations;

public class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    // https://learn.microsoft.com/fr-fr/ef/core/modeling/entity-types?tabs=data-annotations
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasMany(x => x.Items)
            .WithOne(x => x.Brand)
            .HasForeignKey(x => x.BrandId)
            .IsRequired();
    }
}