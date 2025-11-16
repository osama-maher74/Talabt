using LinkDev.Talabat.Domain.Contracts.Presistance.DbInitalizier;

namespace LinkDev.Talabat.APIs.Extintions
{
    public static class InitializerExxtintion
    {
        public static async Task<WebApplication> IntializeDbAsync(this WebApplication app) 
        {
            #region update database on app startup & data seeding
            //creating a scope to get the dbcontext instance explicitly

            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            var StoreContextInitializier = services.GetRequiredService<IstoreDbInitializer>();
            var StoreIdentityDbInitializier = services.GetRequiredService<IStoreIdentityDbInitalizier>();
            var loggerFactory = services.GetRequiredService<ILoggerFactory>();

            try
            {

                await StoreContextInitializier.InitializeAsync();
                await StoreContextInitializier.SeedAsync();
                await StoreIdentityDbInitializier.InitializeAsync();
                await StoreIdentityDbInitializier.SeedAsync();
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "An error occurred while migrating the database.");
            }
            #endregion  

            return app;

        }
    }
}
