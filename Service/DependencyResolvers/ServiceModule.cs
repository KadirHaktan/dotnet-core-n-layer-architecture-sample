using System;
using System.Linq;
using System.Reflection;
using Caching.redis;
using Core.CrossCuttingCornces.Caching;
using Core.Ioc;
using Core.Repository;
using Data.EF;
using Data.EF.Repository;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Models.Concerete.Product;
using Service.Abstract;
using Service.Concerete;

namespace Service.DependencyResolvers
{
    public class ServiceModule : ICoreModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddScoped<IRepository<Product>, EfGenericRepositoryBase<Product,SampleAppContext>>();
            services.AddTransient<IProductService<ProductModel>, ProductModelService>();
            services.AddDbContext<SampleAppContext>(options =>
                options.UseSqlServer(
                    "your connection"));

            services.AddSingleton<ICacheManager, RedisCacheManager>();



        }
    }
}
