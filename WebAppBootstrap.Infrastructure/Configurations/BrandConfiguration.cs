using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAppBootstrap.Domain.Items;

namespace WebAppBootstrap.Infrastructure.Configurations;

public class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    // https://learn.microsoft.com/fr-fr/ef/core/modeling/entity-types?tabs=data-annotations
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        /*
         * La méthode HasKey() est une méthode de l'API Fluent d'Entity Framework Core
         * qui permet de spécifier la clé primaire d'une entité.
         *
         * La clé primaire est un champ ou une combinaison de champs qui identifie
         * de manière unique chaque enregistrement dans une table de la base de données.
         */
        builder.HasKey(x => x.Id);


        /*
         * La méthode HasMany() est une méthode de l'API Fluent d'Entity Framework Core
         * qui permet de spécifier la relation "un à plusieurs" entre deux entités.
         *
         * Dans l'exemple de code fourni, builder.HasMany(x => x.Items)
         * indique que l'entité représentée par la classe Brand a une relation "un à plusieurs"
         * avec l'entité représentée par la classe Item.
         * 
         * La méthode WithOne() spécifie l'entité liée à la relation,
         * qui est l'entité Brand dans ce cas. La méthode HasForeignKey() est utilisée
         * pour spécifier la clé étrangère de la relation, qui est la propriété BrandId de l'entité Item.
         * 
         * Enfin, la méthode IsRequired() spécifie que la clé étrangère BrandId est requise,
         * ce qui signifie qu'une entité Item ne peut pas exister sans être liée à une entité Brand.
         */
        builder.HasMany(x => x.Items)
            .WithOne(x => x.Brand)
            .HasForeignKey(x => x.BrandId)
            .IsRequired();
    }
}