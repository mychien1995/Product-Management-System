using Microsoft.Extensions.DependencyInjection;
using ProductMS.DataAccess.SqlServer.Repositories.Users;
using ProductMS.Framework.Initializations;
using ProductMS.Services.Abstractions;
using ProductMS.Services.Abstractions.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductMS.Services
{
    public class ServiceInitialization : IServiceInitializationModule
    {

        public void Initialize(IServiceCollection services)
        {
            services.AddTransient<IUserManager, EntityUserManager>();
        }
    }
}
