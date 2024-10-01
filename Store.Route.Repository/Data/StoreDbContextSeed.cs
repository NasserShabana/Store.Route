using Store.Route.Core.Entites;
using Store.Route.Repository.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Store.Route.Repository.Data
{
    public static class StoreDbContextSeed
    {

        public async static Task SeedAsync(StoreDbContext _context )
        {
            if (_context.Brands.Count() == 0)
            {
                // Brand
                // 1. Read Data From Json File

                var BrandsData = File.ReadAllText(@"../Store.Route.Repository\Data\DataSeed\brands.json");

                // 2. Convert json String to List<T>

                var Brands = JsonSerializer.Deserialize<List<ProductBrand>>(BrandsData);

                // 3. Seed Data to Database

                if (Brands is not null && Brands.Count() > 0)
                {
                    await _context.Brands.AddRangeAsync(Brands);

                    await _context.SaveChangesAsync();
                }

            }

            if (_context.Types.Count() == 0)
            {
                // Brand
                // 1. Read Data From Json File

                var TypesData = File.ReadAllText(@"../Store.Route.Repository\Data\DataSeed\types.json");

                // 2. Convert json String to List<T>

                var types = JsonSerializer.Deserialize<List<ProductType>>(TypesData);

                // 3. Seed Data to Database

                if (types is not null && types.Count() > 0)
                {
                    await _context.Types.AddRangeAsync(types);

                    await _context.SaveChangesAsync();
                }

            }

            if (_context.Products.Count() == 0)
            {
                // Brand
                // 1. Read Data From Json File

                var ProductsData = File.ReadAllText(@"../Store.Route.Repository\Data\DataSeed\products.json");

                // 2. Convert json String to List<T>

                var products = JsonSerializer.Deserialize<List<Product>>(ProductsData);

                // 3. Seed Data to Database

                if (products is not null && products.Count() > 0)
                {
                    await _context.Products.AddRangeAsync(products);

                    await _context.SaveChangesAsync();
                }

            }


        }
    }
}
