using Api.Controllers;
using Application.ProductService;
using Application.Services;
using AutoFixture;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace ProductControllerTest
{
    public class DeleteProductAsyncTest
    {
        [Fact]
        public async Task Test1()
        {
            var fixture = new Fixture();

            var product = fixture.Create<Product>();
            product.Id = product.Id ?? Guid.NewGuid().ToString();

            var service = new Mock<IProductService>();

            service.Setup(s => s.GetProductByIdAsync(product.Id)).ReturnsAsync(product);

            service.Setup(s => s.DeleteProductAsync(product.Id))
                   .Returns(Task.CompletedTask);

            var controller = new ProductsController(service.Object);

            var result = await controller.DeleteProduct(product.Id) as OkObjectResult;

            Assert.NotNull(result);
            Assert.Equal(product.Id, result.Value);
        }
    }
}
