using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProductMS.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProductMS.DataAccess.Databases
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("Default");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(x => x.ProductId).UseSqlServerIdentityColumn();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> Products { get; set; }
    }
}
