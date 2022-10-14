using Microsoft.Extensions.DependencyInjection;
using OA.Application.Dtos;
using OA.Application.Interfaces;

namespace OA.Test
{
    public class ProductServiceTests
    {
        private IProductService _productService = null!;

        [SetUp]
        public void Setup()
        {
            var serviceProvider = Startup.ServiceProvider;

            _productService = serviceProvider.GetRequiredService<IProductService>();
        }

        [Test]
        public async Task Create_Product_Successfull()
        {
            var product = new ProductCreateOrUpdateDto
            {
                Name = "Test",
                Price = "10,25",
                CreatedAt = DateTime.Now,
            };

            var actualResult = await _productService.InsertProduct(product);

            Assert.IsTrue(actualResult != Guid.Empty);
        }
    }
}