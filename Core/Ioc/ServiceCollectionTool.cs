using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Ioc
{
    public  class ServiceCollectionTool
    {
        public static IServiceProvider serviceProvider { get; set; }

        public static IServiceCollection Create(IServiceCollection services)
        {
            serviceProvider = services.BuildServiceProvider();
            return services;
        }
    }
}
