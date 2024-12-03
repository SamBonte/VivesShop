using Microsoft.EntityFrameworkCore;
using VivesShop.Mvc.WebApp.Models;
using System;

namespace VivesShop.Mvc.WebApp.Core
{
    public class VivesShopDbContext : DbContext
    {
        // constructor om options gedefinieerd in program.cs toe te laten
        // doorgeefLuik naar DbContext omdat DAAR de opties in moeten zitten
        public VivesShopDbContext(DbContextOptions<VivesShopDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products => Set<Product>();

        public void Seed()
        {
            // Id attribute door database geregeld
            var products = new List<Product>
            {
                new Product { ProductName = "Medium Friet", ProductPrice = 3.0},
                new Product { ProductName = "Frikandel", ProductPrice = 2.0},  
                new Product { ProductName = "Cola Zero", ProductPrice = 2.0},
                new Product { ProductName = "Water", ProductPrice = 1.5},
                new Product { ProductName = "Mayonaise", ProductPrice = 0.5}
                
            };

            // in Set zetten om entity framework te gebruiken
            Products.AddRange(products);
            // zal database ook veranderingen aanpassen
            SaveChanges();
        }
    }
}
