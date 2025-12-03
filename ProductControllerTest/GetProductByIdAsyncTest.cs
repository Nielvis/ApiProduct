using Api.Controllers;
using Application.ProductService;
using Application.Services;
using AutoFixture;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace ProductControllerTest
{
    public class GetProductByIdAsyncTest
    {
        [Fact]
        public async Task Test1()
        {
            var fixture = new Fixture();

            var list = fixture.CreateMany<Product>(10).ToList();

            var service = new Mock<IProductService>();

            service.Setup(s => s.GetProductByIdAsync(It.IsAny<string>())).ReturnsAsync(list.First());

            var controller = new ProductsController(service.Object);

            var result = await controller.GetProductById(list.First().Id) as OkObjectResult;

            Assert.NotNull(result);

            var productResult = (Product)result.Value;

            Assert.NotNull(productResult);

            Assert.Equal(list.First().Id, productResult.Id);
        }
    }
}
