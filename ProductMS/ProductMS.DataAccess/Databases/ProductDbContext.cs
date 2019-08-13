using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProductMS.DataAccess.SqlServer.Entities;
using ProductMS.Models.Models.Users;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProductMS.DataAccess.SqlServer.Databases
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
                optionsBuilder.UseSqlServer(connectionString).UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().Property(x => x.ProductId).UseSqlServerIdentityColumn();
            modelBuilder.Entity<ApplicationUserRole>(x => x.HasKey(r => new { r.UserId, r.RoleId }));
            modelBuilder.Entity<ApplicationUserLogin>(b => b.HasKey(x => new { x.LoginProvider, x.ProviderKey, x.UserId }));
            modelBuilder.Entity<ApplicationUserClaim>(b => b.HasKey(x => new { x.Id }));
            modelBuilder.Entity<ApplicationUserToken>(b => b.HasKey(x => new { x.UserId, x.LoginProvider, x.Name }));
            modelBuilder.Entity<ApplicationRoleClaim>(b => b.HasKey(x => new { x.Id }));
            modelBuilder.Entity<ApplicationUser>(b =>
            {
                b.HasMany(e => e.Claims)
                    .WithOne(e => e.User)
                    .HasForeignKey(uc => uc.UserId)
                    .IsRequired();

                b.HasMany(e => e.Logins)
                    .WithOne(e => e.User)
                    .HasForeignKey(ul => ul.UserId)
                    .IsRequired();

                b.HasMany(e => e.Tokens)
                    .WithOne(e => e.User)
                    .HasForeignKey(ut => ut.UserId)
                    .IsRequired();

                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.User)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });

            modelBuilder.Entity<ApplicationRole>(b =>
            {
                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.Role)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                b.HasMany(e => e.RoleClaims)
                    .WithOne(e => e.Role)
                    .HasForeignKey(rc => rc.RoleId)
                    .IsRequired();
            });
        }
        
        public DbSet<Product> Products { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<ApplicationRole> Roles { get; set; }
        public DbSet<ApplicationUserRole> UserRoles { get; set; }
        public DbSet<ApplicationUserLogin> UserLogins { get; set; }
        public DbSet<ApplicationUserClaim> UserClaims { get; set; }
        public DbSet<ApplicationUserToken> UserTokens { get; set; }
        public DbSet<ApplicationRoleClaim> RoleClaims { get; set; }
    }
}
