using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProductMS.DataAccess.SqlServer.Entities;
using System.IO;

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
            modelBuilder.Entity<Product>().Property(x => x.ProductId).UseSqlServerIdentityColumn();
            modelBuilder.Entity<Article>().Property(x => x.ArticleId).UseSqlServerIdentityColumn();
            modelBuilder.Entity<Article>()
                .HasOne(p => p.CreatedByUser)
                .WithMany(b => b.ArticlesCreated).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Article>()
               .HasOne(p => p.UpdatedByUser)
               .WithMany(b => b.ArticlesUpdated).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Province>().HasOne(p => p.Country).WithMany(x => x.Provinces).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<District>().HasOne(p => p.Province).WithMany(x => x.Districts).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Address>().Property(x => x.AddressId).UseSqlServerIdentityColumn();
            modelBuilder.Entity<Address>().HasOne(p => p.Country).WithMany(x => x.Addresses).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Address>().HasOne(p => p.District).WithMany(x => x.Addresses).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Address>().HasOne(p => p.Province).WithMany(x => x.Addresses).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Organization>().Property(x => x.OrganizationId).UseSqlServerIdentityColumn();
            modelBuilder.Entity<Organization>().HasOne(p => p.Province).WithMany(x => x.Organizations).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<OrganizationAddress>().HasOne(p => p.Organization).WithMany(x => x.Addresses).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<OrganizationAddress>().HasOne(p => p.Address).WithMany(x => x.Organizations).OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<ApplicationRole> Roles { get; set; }
        public DbSet<ApplicationRoleClaim> RoleClaims { get; set; }
        public DbSet<ApplicationUserRole> UserRoles { get; set; }
        public DbSet<ApplicationUserLogin> UserLogins { get; set; }
        public DbSet<ApplicationUserClaim> UserClaims { get; set; }
        public DbSet<ApplicationUserToken> UserTokens { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<OrganizationAddress> OrganizationAddresses { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Language> Languages { get; set; }
    }
}
