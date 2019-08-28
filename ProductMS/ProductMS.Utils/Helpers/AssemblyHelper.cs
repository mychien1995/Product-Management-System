using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace ProductMS.Utils.Helpers
{
    public static class AssemblyHelper
    {
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
