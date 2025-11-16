using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using LinkDev.Talabat.Domain.Contracts.Presistance.DbInitalizier;
using LinkDev.Talabat.Domain.Entites.Products;
using LinkDev.Talabat.Infrastracture.Persistence.Common;
using Microsoft.EntityFrameworkCore;

namespace LinkDev.Talabat.Infrastracture.Persistence.Data
{
    internal class StoreDbInitializer(StoreDbContext dbContext) : DbInitalizier(dbContext), IstoreDbInitializer
    {
        

        public override async Task SeedAsync()   
        {
            if (!dbContext.Brands.Any())
            {
                var curentDirectory = Directory.GetCurrentDirectory();

                var brandsData = await File.ReadAllTextAsync("../LinkDev.Talabat.Infrastracture.Persistence/Data/Seeds/brands.json");

                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                if (brands?.Count > 0)
                {

                    await dbContext.Set<ProductBrand>().AddRangeAsync(brands);
                    await dbContext.SaveChangesAsync();
                }
            }

            if (!dbContext.Categories.Any())
            {
                var curentDirectory = Directory.GetCurrentDirectory();

                var categoriesData = await File.ReadAllTextAsync("../LinkDev.Talabat.Infrastracture.Persistence/Data/Seeds/categories.json");

                var categories = JsonSerializer.Deserialize<List<ProductCategory>>(categoriesData, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                if (categories?.Count > 0)
                {

                    await dbContext.Set<ProductCategory>().AddRangeAsync(categories);
                    await dbContext.SaveChangesAsync();
                }
            }

            if (!dbContext.Products.Any())
            {
                var curentDirectory = Directory.GetCurrentDirectory();

                var productsData = await File.ReadAllTextAsync("../LinkDev.Talabat.Infrastracture.Persistence/Data/Seeds/products.json");

                var products = JsonSerializer.Deserialize<List<Product>>(productsData, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                if (products?.Count > 0)
                {

                    await dbContext.Set<Product>().AddRangeAsync(products);
                    await dbContext.SaveChangesAsync();
                }
            }
        }
    }

}

