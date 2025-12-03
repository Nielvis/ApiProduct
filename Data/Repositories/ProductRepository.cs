using Domain.Entities;
using Domain.Interfaces;
using Domain.Settings;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMongoCollection<Product> _products;
        public ProductRepository(MongoDbSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _products = database.GetCollection<Product>("Products");
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _products.Find(_ => true).ToListAsync();
        }

       public async Task<Product> GetProductById(string Id)
       {
           return await _products.Find(product => product.Id == Id).FirstOrDefaultAsync();
       }

        public async Task CreateProduct(Product product)
        {
            await _products.InsertOneAsync(product);
        }

        public async Task UpdateProduct(string Id, Product product)
        {
            await _products.ReplaceOneAsync(p => p.Id == Id, product);
        }

        public async Task DeleteProduct(string Id)
        {
            await _products.DeleteOneAsync(p => p.Id == Id);
        }
    }
}
