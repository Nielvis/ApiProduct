using Application.Services;
using Domain.Entities;
using Domain.Interfaces;
using Application.ProductService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<List<Product>> GetAllProductsAsync()
            => _productRepository.GetAllProducts();

        public Task<Product> GetProductByIdAsync(string id)
            => _productRepository.GetProductById(id);

        public Task CreateProductAsync(Product product)
            => _productRepository.CreateProduct(product);

        public Task UpdateProductAsync(string id, Product product)
            => _productRepository.UpdateProduct(id, product);

        public Task DeleteProductAsync(string id)
            => _productRepository.DeleteProduct(id);
    }
}
