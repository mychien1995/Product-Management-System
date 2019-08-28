using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using NetCore.AutoRegisterDi;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProductMS.Framework.Configurations;
using ProductMS.Utils.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductMS.Framework.Initializations
{
    public class InitializationModule
    {

        public static void InitializeServices(IServiceCollection services)
        {
            InitializeGenericServices(services);

            var hostingEnvironment = services.BuildServiceProvider().GetService<IHostingEnvironment>();
            string webRootPath = hostingEnvironment.ContentRootPath;
            var configFilePath = webRootPath + "/Config/app.initialization.json";
            var configFileContent = System.IO.File.ReadAllText(configFilePath);
            var configModule = JObject.Parse(configFileContent);
            var initializationModules = configModule["serviceInitializations"];
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

        private static void InitializeGenericServices(IServiceCollection services)
        {
            var assemblies = AssemblyHelper.GetAssemblies(x => x.Name.StartsWith("ProductMS")).ToArray();
            services.RegisterAssemblyPublicNonGenericClasses(assemblies).AsPublicImplementedInterfaces();
        }
    }
}
