using Api.Controllers;
using Application.ProductService;
using AutoFixture;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;

namespace TestProject
{
    public class UnitTest1
    {
        [Fact]
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
