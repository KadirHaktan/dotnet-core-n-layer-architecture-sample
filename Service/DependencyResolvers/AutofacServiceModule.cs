using System;
using System.Collections.Generic;
using System.Reflection;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Core.Aspects.Base;
using Module = Autofac.Module;

namespace Service.DependencyResolvers
{
    public class AutofacServiceModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assemblies = Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assemblies)
                .AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
