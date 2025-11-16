using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkDev.Talabat.Domain.Contracts.Presistance.DbInitalizier;
using Microsoft.EntityFrameworkCore;

namespace LinkDev.Talabat.Infrastracture.Persistence.Common
{
    public abstract class DbInitalizier(DbContext dbContext) : IDbInitalizier
    {
        public  async Task InitializeAsync()
        {
            var pendingMigrations = dbContext.Database.GetPendingMigrations();
            if (pendingMigrations.Any())
            {

                await dbContext.Database.MigrateAsync(); //update database to latest migration
            }
        }

        public abstract Task SeedAsync();
       
    }
}
