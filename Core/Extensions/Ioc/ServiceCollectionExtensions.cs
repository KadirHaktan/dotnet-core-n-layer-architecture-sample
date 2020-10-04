using System;
using System.Collections.Generic;
using System.Text;
using Core.Ioc;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Extensions.Ioc
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection services, ICoreModule[] modules)
        {
            foreach (var module in modules )
            {
                module.Load(services);
            }

            return ServiceCollectionTool.Create(services);
        }
    }
}
