using Catalog.Api.Entities;
using MongoDB.Driver;
using System.Reflection;
using System.Text.Json;

namespace Catalog.Api.Data
{
    public class CatalogContextSeed
    {
        public static async Task SeedData(IMongoCollection<Product> productCollection)
        {
            if (!productCollection.Find(x => true).Any())
            {
                await productCollection.InsertManyAsync(GetPreconfiguredProducts());
            }
        }

        private static IEnumerable<Product> GetPreconfiguredProducts()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            var productsData = File.ReadAllText(path + @"/Data/SeedData/products.json");

            var products = JsonSerializer.Deserialize<List<Product>>(productsData);

            return products;
        }
    }
}
