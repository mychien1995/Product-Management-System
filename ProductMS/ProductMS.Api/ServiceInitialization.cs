using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductMS.Api.Extensions;
using ProductMS.Framework.Initializations;

namespace ProductMS.Api.Initializations
{
    public class ConfigureCorsInitialization : IServiceInitializationModule
    {
        public void Initialize(IServiceCollection services)
        {
            services.ConfigureCors();
        }
    }

    public class ConfigureIdentityInitialization : IServiceInitializationModule
    {
        public void Initialize(IServiceCollection services)
        {
            var _configuration = services.BuildServiceProvider().GetService<IConfiguration>();
            services.ConfigureIdentity(_configuration["Tokens:Key"], _configuration["Tokens:Audience"], _configuration["Tokens:Issuer"]);
        }
    }

    public class ConfigureMvcInitialization : IServiceInitializationModule
    {
        public void Initialize(IServiceCollection services)
        {
            services.ConfigureMvc();
        }
    }
}
