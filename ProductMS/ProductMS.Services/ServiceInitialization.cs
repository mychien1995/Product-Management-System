using Microsoft.Extensions.DependencyInjection;
using ProductMS.Framework.Initializations;
using ProductMS.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using EntityProvider = ProductMS.Services.Entities.Providers;

namespace ProductMS.Services
{
    public class ServiceInitialization : IServiceInitialization
    {
        public int Order => 2;

        public bool Enabled => true;

        public void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<IProductDataProvider, EntityProvider.ProductDataProvider>();
        }
    }
}
