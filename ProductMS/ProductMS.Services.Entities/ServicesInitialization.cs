﻿using Microsoft.Extensions.DependencyInjection;
using ProductMS.DataAccess.SqlServer.Entities;
using ProductMS.Framework.Initializations;
using ProductMS.Models.Products;
using ProductMS.Services.Abstractions;
using ProductMS.Services.Entities.Transformers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductMS.Services.Entities
{
    public class ServicesInitialization : IInitializableModule
    {
        public void Initialize()
        {

        }

        public void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<IModelTransformer<ProductModel, Product>, ProductEntityTransformer>();
        }
    }
}
