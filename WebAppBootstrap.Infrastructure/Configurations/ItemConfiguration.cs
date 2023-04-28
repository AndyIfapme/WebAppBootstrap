using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAppBootstrap.Domain.Items;

namespace WebAppBootstrap.Infrastructure.Configurations;

public class ItemConfiguration : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        /*
         * La méthode HasKey() est une méthode de l'API Fluent d'Entity Framework Core
         * qui permet de spécifier la clé primaire d'une entité.
         *
         * La clé primaire est un champ ou une combinaison de champs qui identifie
         * de manière unique chaque enregistrement dans une table de la base de données.
         */
        builder.HasKey(x => x.Id);
    }
}