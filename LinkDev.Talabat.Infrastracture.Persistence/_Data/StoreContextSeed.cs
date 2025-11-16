using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using LinkDev.Talabat.Domain.Entites.Products;

namespace LinkDev.Talabat.Infrastracture.Persistence.Data
{
    public static class StoreContextSeed
    {
        public static async Task SeedAsync(StoreDbContext context)
        {
            if(!context.Brands.Any())
            { 
                var curentDirectory = Directory.GetCurrentDirectory();

                 var brandsData = await File.ReadAllTextAsync("../LinkDev.Talabat.Infrastracture.Persistence/Data/Seeds/brands.json");
            
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                if (brands?.Count>0)
                {

                       await context.Set<ProductBrand>().AddRangeAsync(brands);
                       await context.SaveChangesAsync();
                }
            }

            if (!context.Categories.Any())
            {
                var curentDirectory = Directory.GetCurrentDirectory();

                var categoriesData = await File.ReadAllTextAsync("../LinkDev.Talabat.Infrastracture.Persistence/Data/Seeds/categories.json");

                var categories = JsonSerializer.Deserialize<List<ProductCategory>>(categoriesData, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                if (categories?.Count > 0)
                {

                    await context.Set<ProductCategory>().AddRangeAsync(categories);
                    await context.SaveChangesAsync();
                }
            }

            if (!context.Products.Any())
            {
                var curentDirectory = Directory.GetCurrentDirectory();

                var productsData = await File.ReadAllTextAsync("../LinkDev.Talabat.Infrastracture.Persistence/Data/Seeds/products.json");

                var products = JsonSerializer.Deserialize<List<Product>>(productsData, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                if (products?.Count > 0)
                {

                    await context.Set<Product>().AddRangeAsync(products);
                    await context.SaveChangesAsync();
                }
            }
        }
    }
} 
