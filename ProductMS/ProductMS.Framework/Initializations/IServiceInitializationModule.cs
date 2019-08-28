using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductMS.Framework.Initializations
{
    public interface IServiceInitializationModule
    {
        void Initialize(IServiceCollection services);
    }
}
