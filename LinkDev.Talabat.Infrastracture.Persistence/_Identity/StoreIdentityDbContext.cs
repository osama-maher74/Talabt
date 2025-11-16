using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkDev.Talabat.Domain.Entites.Identity;
using LinkDev.Talabat.Infrastracture.Persistence._Identity.Config;
using LinkDev.Talabat.Infrastracture.Persistence.Identity.Config;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LinkDev.Talabat.Infrastracture.Persistence.Identity
{
    public class StoreIdentityDbContext: IdentityDbContext<ApplicationUser>
    {
        public StoreIdentityDbContext(DbContextOptions<StoreIdentityDbContext> options) : base(options)
        {

        }

         protected override void OnModelCreating(ModelBuilder builder)
         {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new ApplicationUserConfigrations());
            builder.ApplyConfiguration(new AdressConfigrations());


        }

       

    }
}
