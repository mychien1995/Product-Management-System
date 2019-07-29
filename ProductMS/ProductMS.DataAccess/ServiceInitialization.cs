using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProductMS.DataAccess.SqlServer.Databases;
using ProductMS.Framework.Initializations;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductMS.DataAccess.SqlServer
{
    public class ServiceInitialization : IServiceInitialization
    {
        public int Order => 0;

        public bool Enabled => true;

        public void RegisterServices(IServiceCollection services)
        {
            services.AddDbContext<ProductDbContext>();
            using (var context = new ProductDbContext())
            {
                context.Database.Migrate();
            }
        }
    }
}
