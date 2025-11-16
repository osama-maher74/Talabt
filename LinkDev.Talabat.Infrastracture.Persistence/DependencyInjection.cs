using LinkDev.Talabat.Domain.Contracts.Presistance;
using LinkDev.Talabat.Domain.Contracts.Presistance.DbInitalizier;
using LinkDev.Talabat.Infrastracture.Persistence.Data;
using LinkDev.Talabat.Infrastracture.Persistence.Identity;
using LinkDev.Talabat.Infrastracture.Persistence.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LinkDev.Talabat.Infrastracture.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<StoreDbContext>(options =>
            {
                options.UseLazyLoadingProxies()
                .UseSqlServer(configuration.GetConnectionString("StoreContext"));
            });
            services.AddDbContext<StoreIdentityDbContext>(options =>
            {
                options.UseLazyLoadingProxies()
                .UseSqlServer(configuration.GetConnectionString("IdentityContext"));
            });

            services.AddScoped(typeof(IstoreDbInitializer), typeof(StoreDbInitializer));
            services.AddScoped(typeof(IStoreIdentityDbInitalizier), typeof(StoreIdentityDbInitalizier));
            services.AddScoped(typeof(IUnitOfWork), typeof(unitOfWork));
            
            return services;
        }
    }
}
