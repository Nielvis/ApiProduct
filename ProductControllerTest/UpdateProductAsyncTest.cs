using Api.Controllers;
using Application.ProductService;
using Application.Services;
using AutoFixture;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace ProductControllerTest
{
    public class UpdateProductAsyncTest
    {
        [Fact]
        public async Task UpdateProduct_ReturnsUpdatedProduct()
        {
            var fixture = new Fixture();

            var existing = fixture.Create<Product>();

            existing.Id = existing.Id ?? Guid.NewGuid().ToString();

            var updatedProduct = fixture.Create<Product>();
            updatedProduct.Id = existing.Id;

            var service = new Mock<IProductService>();

            service.Setup(s => s.GetProductByIdAsync(existing.Id))
                   .ReturnsAsync(existing);

            service.Setup(s => s.UpdateProductAsync(existing.Id, updatedProduct))
                   .Returns(Task.CompletedTask);

            var controller = new ProductsController(service.Object);

            var result = await controller.UpdateProduct(existing.Id, updatedProduct) as OkObjectResult;

            Assert.NotNull(result);

            var returnedProduct = (Product)result.Value;

            Assert.Equal(updatedProduct.Id, returnedProduct.Id);
            Assert.Equal(updatedProduct.Name, returnedProduct.Name);
            Assert.Equal(updatedProduct.Price, returnedProduct.Price);
        }
    }
}
