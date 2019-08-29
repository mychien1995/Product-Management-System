using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using NetCore.AutoRegisterDi;
using Newtonsoft.Json.Linq;
using ProductMS.Framework.IoC;
using ProductMS.Utils.Helpers;
using System;
using System.Linq;
using System.Reflection;

namespace ProductMS.Framework.Initializations
{
    public class InitializationModule
    {

        public static void InitializeServices(IServiceCollection services)
        {
            var assemblies = AssemblyHelper.GetAssemblies(x => x.Name.StartsWith("ProductMS")).ToArray();
            InitializeDefaultServices(services, assemblies);
            InitializeCustomServices(services, assemblies);
            InitializeModules(services);
        }

        private static void InitializeDefaultServices(IServiceCollection services, Assembly[] assemblies)
        {
            services.RegisterAssemblyPublicNonGenericClasses(assemblies).AsPublicImplementedInterfaces();
        }

        private static void InitializeCustomServices(IServiceCollection services, Assembly[] assemblies)
        {
            var types = AssemblyHelper.GetClassesWithAttribute(assemblies, typeof(ServiceTypeOfAttribute));
            foreach (var type in types)
            {
                var attr = ((ServiceTypeOfAttribute)type.GetCustomAttribute(typeof(ServiceTypeOfAttribute)));
                var parentType = attr.ServiceType;
                var scope = attr.LifetimeScope;
                switch (scope)
                {
                    case LifetimeScope.Transient:
                        services.AddTransient(parentType, type);
                        break;
                    case LifetimeScope.Singleton:
                        services.AddSingleton(parentType, type);
                        break;
                    case LifetimeScope.PerRequest:
                        services.AddScoped(parentType, type);
                        break;
                    default:
                        services.AddTransient(parentType, type);
                        break;
                }
            }
        }

        private static void InitializeModules(IServiceCollection services)
        {
            var hostingEnvironment = services.BuildServiceProvider().GetService<IHostingEnvironment>();
            string webRootPath = hostingEnvironment.ContentRootPath;
            var configFilePath = webRootPath + "/Config/app.initialization.json";
            var configFileContent = System.IO.File.ReadAllText(configFilePath);
            var configModule = JObject.Parse(configFileContent);
            var initializationModules = configModule["initializations"];
            foreach (var moduleType in initializationModules)
            {
                var instanceType = Type.GetType(moduleType["type"].ToString(), true, true);
                var instance = Activator.CreateInstance(instanceType);
                if (instance is IServiceInitializationModule)
                {
                    ((IServiceInitializationModule)instance).Initialize(services);
                }
            }
        }
    }
}
