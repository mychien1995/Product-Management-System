using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProductMS.DataAccess.SqlServer.Databases;
using ProductMS.Framework.Initializations;

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
        }
    }
}
