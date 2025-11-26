using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IProductRepository 
    {
        Task<List<Product>> GetAllProducts();
        Task<Product> GetProductById(string Id);
        Task CreateProduct(Product product);
        Task UpdateProduct(string Id, Product product);
        Task DeleteProduct(string Id);
    }
}
