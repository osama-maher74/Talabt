using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using LinkDev.Talabat.Domain.Contracts.Presistance.DbInitalizier;
using LinkDev.Talabat.Domain.Entites.Identity;
using LinkDev.Talabat.Domain.Entites.Products;
using LinkDev.Talabat.Infrastracture.Persistence.Common;
using LinkDev.Talabat.Infrastracture.Persistence.Data;
using LinkDev.Talabat.Infrastracture.Persistence.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LinkDev.Talabat.Infrastracture.Persistence.Identity
{
    public class StoreIdentityDbInitalizier(StoreIdentityDbContext dbContext,UserManager<ApplicationUser> userManager) : DbInitalizier(dbContext), IStoreIdentityDbInitalizier
    {

        public override async Task SeedAsync()
        {
            if (!userManager.Users.Any())
            { 
                var user = new ApplicationUser
                {

                    DisplayName = "Osama Maher",
                    UserName = "osama.maher",
                    Email = "osama.maher@no.com",
                    PhoneNumber = "01000000000"

                };
                await userManager.CreateAsync(user, "Osama@123");
            }
        }
            
    } 
}

