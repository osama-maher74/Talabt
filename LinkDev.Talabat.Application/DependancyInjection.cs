using System;
using AutoMapper;
using LinkDev.Talabat.Application.Abstraction.Services;
using LinkDev.Talabat.Application.Abstraction.Services.Basket;
using LinkDev.Talabat.Application.Abstraction.Services.Products;
using LinkDev.Talabat.Application.Mapping;
using LinkDev.Talabat.Application.Services;
using LinkDev.Talabat.Application.Services.Baskets;
using LinkDev.Talabat.Application.Services.Products;
using LinkDev.Talabat.Domain.Infrastrcrture;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace LinkDev.Talabat.Application
{
    public static class DependancyInjection
    {

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Add AutoMapper
            services.AddAutoMapper(typeof(MappingProfile));

            // Add other application services here
           
            services.AddScoped(typeof(IServiceManger), typeof(ServiceManger));
            services.AddScoped(typeof(Func<IBasketServics>), (servicesProvider) =>
                {

                    //var mapper = servicesProvider.GetRequiredService<IMapper>();
                    //var configuration = servicesProvider.GetRequiredService<IConfiguration>();
                    // var basketRepositry = servicesProvider.GetRequiredService<IBasketRepositry>();

                    //return ()=> new BasketService(basketRepositry,mapper, configuration );
                    return () => servicesProvider.GetRequiredService<IBasketServics>();
                });

            return services;
        }

    }
}
