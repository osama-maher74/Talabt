using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkDev.Talabat.Domain.Infrastrcrture;
using LinkDev.Talabat.Infrastracture.Basket_Repositry;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace LinkDev.Talabat.Infrastracture
{
    public static class DependancyInjection
    {
        public static IServiceCollection AddInfrastractureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Add your infrastructure services here, e.g., database contexts, repositories, etc.
            services.AddScoped(typeof(IConnectionMultiplexer), (serviceProvider) =>
            { 
                var connectionString = configuration.GetConnectionString("Redis");
                var connectionMultiplexerObj = ConnectionMultiplexer.Connect(connectionString!);
                return connectionMultiplexerObj;
            });

            services.AddScoped(typeof(IBasketRepositry), typeof(BasketRepositry));
            return services;
        }
    }
}
