using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shop.ApplicationServices.Services;
using Shop.Core.ServiceInterface;
using Shop.Data;
using Shop.KindergartenTest.Macros;
using Shop.KindergartenTest.Mock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.KindergartenTest
{
    public class TestBase
    {
        protected IServiceProvider ServiceProvider { get; }

        protected TestBase() 
        {
            var services=new ServiceCollection();
            SetupServices(services);
            ServiceProvider = services.BuildServiceProvider();
        }
        public void Dispose() 
        { 

        }
        protected T Svc<T> ()
        {
            return ServiceProvider.GetService<T>();
        }

        protected T Macro<T>() where T: IMacros
        {
            return ServiceProvider.GetService<T>();
        }

        public virtual void SetupServices(IServiceCollection services)
        {
            services.AddScoped<IKindergartenServices, KinderGartenServices>();
            services.AddScoped<IFileServices, FileServices>();
            services.AddScoped<IHostEnvironment, MockHostEnvironment>();



            services.AddDbContext<ShopContext>(x =>
            {
                x.UseInMemoryDatabase("TEST");
                x.ConfigureWarnings(e=>e.Ignore(InMemoryEventId.TransactionIgnoredWarning));

            });
            RegisterMacros(services);

        }
        private void RegisterMacros(IServiceCollection services)
        {
            var macrosBaseType = typeof(IMacros);

            var macros = macrosBaseType.Assembly.GetTypes()
                .Where(x => macrosBaseType.IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract);

            foreach (var macro in macros)
            {
                services.AddSingleton(macro);

            }
        }
    }
}
