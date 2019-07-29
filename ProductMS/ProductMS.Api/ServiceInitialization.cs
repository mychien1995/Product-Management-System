using Microsoft.Extensions.DependencyInjection;
using ProductMS.Framework.Initializations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace ProductMS.Api
{
    public static class ServiceInitialization
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            var assemblies = GetAssemblies(x=>x.Name.StartsWith("ProductMS"));
            var allRegiterEntryPoints = assemblies.SelectMany(x => x.GetTypes())
            .Where(x => typeof(IServiceInitialization).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract).ToList();
            var instanceList = allRegiterEntryPoints.Select(type => (IServiceInitialization)Activator.CreateInstance(type)).Where(x => x.Enabled).OrderBy(x => x.Order).ToList();
            foreach (var initialization in instanceList)
            {
                initialization.RegisterServices(services);
            }
        }

        public static IEnumerable<Assembly> GetAssemblies(Expression<Func<AssemblyName, bool>> predicate)
        {
            var list = new List<string>();
            var stack = new Stack<Assembly>();
            var compiled = predicate.Compile();
            stack.Push(Assembly.GetEntryAssembly());
            
            do
            {
                var asm = stack.Pop();

                yield return asm;

                foreach (var reference in asm.GetReferencedAssemblies())
                    if (compiled.Invoke(reference))
                    {
                        stack.Push(Assembly.Load(reference));
                        list.Add(reference.FullName);
                    }

            }
            while (stack.Count > 0);

        }
    }
}
