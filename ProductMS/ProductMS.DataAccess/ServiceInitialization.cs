using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProductMS.DataAccess.SqlServer.Databases;
using ProductMS.DataAccess.SqlServer.Entities;
using ProductMS.Framework.Initializations;
using ProductMS.Models.Articles;
using ProductMS.Models.Models.Users;
using ProductMS.Models.Products;
using ProductMS.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductMS.DataAccess.SqlServer
{
    public class ServiceInitialization : IServiceInitializationModule
    {
        public void Initialize(IServiceCollection services)
        {
            services.AddDbContext<ProductDbContext>();
            using (var context = new ProductDbContext())
            {
                context.Database.Migrate();
            }
            services.AddTransient<IModelTransformer<ProductModel, Product>, ProductEntityTransformer>();
            services.AddTransient<IModelTransformer<UserModel, ApplicationUser>, UserEntityTransformer>();
            services.AddTransient<IModelTransformer<ArticleModel, Article>, ArticleEntityTransformer>();
        }
    }
}
