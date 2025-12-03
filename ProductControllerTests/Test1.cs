using Api.Controllers;
using Application.ProductService;
using Application.Services;
using AutoFixture;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace ProductControllerTests
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public async Task Test1()
            {
            var fixture = new Fixture();

            var list = fixture.CreateMany<Product>(10).ToList();

            var service = new Mock<IProductService>();

            service.Setup(s => s.GetAllProductsAsync())
                .ReturnsAsync(list);

            var controller = new ProductsController(service.Object);

            var result = await controller.GetAllProducts() as OkObjectResult;

            var listResult = (List<Product>)result.Value;

            Assert.NotNull(result);

            Assert.Equal(10, listResult.Count);
        }
    }
    
}
