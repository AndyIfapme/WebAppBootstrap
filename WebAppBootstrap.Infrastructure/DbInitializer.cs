﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebAppBootstrap.Domain.Items;
using WebAppBootstrap.Domain.Users;

namespace WebAppBootstrap.Infrastructure;

public static class DbInitializer
{
    public static void Initialize(DbContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
    {
        /*
         * La méthode EnsureDeleted() est une méthode fournie par Entity Framework Core
         * qui permet de supprimer la base de données associée au contexte de données.
         *
         * Cette méthode est utile pour nettoyer la base de données avant de la recréer
         * ou pour supprimer complètement la base de données.
         */
        context.Database.EnsureDeleted();

        /*
         * La méthode EnsureCreated() est une méthode fournie par Entity Framework Core
         * qui permet de créer la base de données associée
         * au contexte de données s'il n'existe pas déjà.
         *
         * Cette méthode est utilisée lors de la configuration initiale de l'application
         * pour s'assurer que la base de données a été créée avec le schéma requis.
         *
         */
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
                    Price = 800.00,
                    ImageUrl = "/imgs/items/nike-jordan.webp"
                }
            }
        });

        var role = new IdentityRole("Admin");
        var user = new User { UserName = "admin@admin.be", Email = "admin@admin.be" };

        roleManager.CreateAsync(role)
            .GetAwaiter()
            .GetResult();

        userManager.CreateAsync(user, "Azerty123!")
            .GetAwaiter()
            .GetResult();

        userManager.AddToRoleAsync(user, "Admin")
            .GetAwaiter()
            .GetResult();

        /*
         * La méthode SaveChanges() est une méthode fournie par Entity Framework Core
         * qui permet de sauvegarder les modifications apportées aux entités associées
         * au contexte de données dans la base de données.
         *
         * Cette méthode doit être appelée pour persister les changements apportés
         * aux données dans la base de données.
         */
        context.SaveChanges();
    }
}