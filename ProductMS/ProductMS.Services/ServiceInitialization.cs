using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductMS.DataAccess.SqlServer.Databases;
using ProductMS.Models.Interfaces;
using ProductMS.Models.Products;
using ProductMS.Services.Products;
using ProductMS.Services.Transforms;
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

        public static void RegisterGenericServices(this IServiceCollection services)
        {
            services.AddTransient(typeof(IEntityService<IModelTransformable<ProductModel>>), typeof(IProductEntityService));
            services.AddTransient(typeof(IModelTransformer<ProductModel>), typeof(ProductTransformer));
        }
    }
}
