using Microsoft.Extensions.DependencyInjection;
using ProductMS.Framework.Initializations;
using ProductMS.Services.Abstractions;
using ProductMS.Services.Abstractions.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using EntityProvider = ProductMS.DataAccess.SqlServer.Providers;

namespace ProductMS.Services
{
    public class ServiceInitialization : IServiceInitializationModule
    {

        public void Initialize(IServiceCollection services)
        {
            services.AddTransient<IProductDataProvider, EntityProvider.ProductDataProvider>();
            services.AddTransient<IUserManager, EntityProvider.Users.EntityUserManager>();
            services.AddTransient<IArticleDataProvider, EntityProvider.ArticleDataProvider>();
        }
    }
}
