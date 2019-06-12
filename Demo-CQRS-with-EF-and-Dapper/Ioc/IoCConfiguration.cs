namespace Demo.Ioc
{
    using CQRS;
    using CQRS.Commons;
    using CQRS.Services;
    using CQRS.UnitOfWork;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.DependencyInjection;
    using System;

    public class IoCConfiguration
    {
        private static IUnitOfWork UnitOfWorkFactory(IServiceProvider serviceProvider)
        {
            object factory = serviceProvider.GetService<IHttpContextAccessor>();

            HttpContext context = ((HttpContextAccessor)factory).HttpContext;

            return new UnitOfWork(context, serviceProvider.GetService<DemoDbContext>());
        }

        public static void RegisterIoC(IServiceCollection services)
        {
            services.AddScoped(UnitOfWorkFactory);
            services.AddScoped<IDapperContext, DapperContext>();
            services.AddScoped<CQRS.ISession, Session>();
            services.AddScoped<IDatabase, Database>();

            services.AddScoped<IAnimalService, AnimalService>();

            ResolverFactory.SetProvider(services.BuildServiceProvider());
        }
    }
}
