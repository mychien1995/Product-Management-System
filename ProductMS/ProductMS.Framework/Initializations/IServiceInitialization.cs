using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductMS.Framework.Initializations
{
    public interface IServiceInitialization
    {
        int Order { get; }

        bool Enabled { get; }
        void RegisterServices(IServiceCollection services);
    }
}
