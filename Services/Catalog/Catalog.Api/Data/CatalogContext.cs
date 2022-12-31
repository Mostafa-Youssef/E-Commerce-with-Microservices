using Catalog.Api.Entities;
using MongoDB.Driver;

namespace Catalog.Api.Data
{
    public class CatalogContext : ICatalogContext
    {
        public CatalogContext(IConfiguration configuration) 
        {
            var client = new MongoClient(configuration.GetValue<string>("DataBaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DataBaseSettings:DatabaseName"));

            Products = database.GetCollection<Product>(configuration.GetValue<string>("DataBaseSettings:CollectionName"));
        }
        public IMongoCollection<Product> Products { get; }
    }
}
