using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Ioc
{
    public interface ICoreModule
    {
        void Load(IServiceCollection services);
    }
}
