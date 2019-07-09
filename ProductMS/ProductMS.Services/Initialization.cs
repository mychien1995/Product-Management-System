using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductMS.DataAccess.Databases;
using System;

namespace ProductMS.Services
{
    public static class ServiceInitialization
    {
        public static void AddSqlDataAccess(this IServiceCollection services)
        {
            services.AddDbContext<ProductDbContext>();
            using(var context = new ProductDbContext())
            {
                context.Database.Migrate();
            }
        }
    }
}
