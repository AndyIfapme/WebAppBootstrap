using Microsoft.EntityFrameworkCore;
using WebAppBootstrap.Domain.Items;

namespace WebAppBootstrap.Infrastructure;

public static class DbInitializer
{
    public static void Initialize(DbContext context)
    {
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        context.Set<Brand>().Add(new Brand
        {
            Name = "Nike",
            Items = new List<Item>
            {
                new Item
                {
                    Name = "Air MAX",
                    Description = "AirMax modéle 2018",
                    Price = 150.00
                },
                new Item
                {
                    Name = "Jordan",
                    Description = "jordan edition limité  2022",
                    Price = 800.00
                }
            }
        });

        context.SaveChanges();
    }
}