using Catalog.Api.Entities;
using MongoDB.Driver;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Catalog.Api.Data
{
    public class CatalogContextSeed
    {
        public static void SeedData(IMongoCollection<Product> productCollection)
        {
            if (!productCollection.Find(x => true).Any())
            {
                productCollection.InsertManyAsync(GetPreconfiguredProducts());
            }
        }

        private static IEnumerable<Product> GetPreconfiguredProducts()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            var productsData = File.ReadAllText(path + @"/Data/SeedData/products.json");

            var products = JsonSerializer.Deserialize<List<Product>>(productsData, new JsonSerializerOptions()
            {
                NumberHandling = JsonNumberHandling.AllowReadingFromString |
                JsonNumberHandling.WriteAsString
            });

            return products;
        }
    }
}
