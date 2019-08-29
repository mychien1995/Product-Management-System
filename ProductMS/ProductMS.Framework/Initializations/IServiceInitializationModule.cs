using Microsoft.Extensions.DependencyInjection;

namespace ProductMS.Framework.Initializations
{
    public interface IServiceInitializationModule
    {
        void Initialize(IServiceCollection services);
    }
}
