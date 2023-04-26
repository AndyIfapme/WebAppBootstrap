using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebAppBootstrap.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Appel automatiquement les configurations héritant de IEntityTypeConfiguration dans l'assembly défini.
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            //builder.ApplyConfiguration(new BrandConfiguration());
            //builder.ApplyConfiguration(new ItemConfiguration());

            base.OnModelCreating(builder);
        }
    }
}