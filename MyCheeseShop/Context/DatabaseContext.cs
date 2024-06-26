﻿using MyCheeseShop.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MyCheeseShop.Context
{
    public class DatabaseContext : IdentityDbContext<User>
    {
        private IWebHostEnvironment _environment;

        public DbSet<Cheese> Cheeses { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options, IWebHostEnvironment environment) : base(options)
        {
            _environment = environment;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsbuilder)
        {
            var folder = Path.Combine(_environment.WebRootPath, "Database");
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            optionsbuilder.UseSqlite($"Data Source={folder}/cheese.db");
        }
  
    }
}
