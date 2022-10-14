using Microsoft.AspNetCore.Mvc;
using OA.Application.Dtos;
using OA.Application.Interfaces;

namespace OA.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductServiceController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductServiceController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await productService.GetAllProducts();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var response = await productService.GetProduct(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProductCreateOrUpdateDto product)
        {
            var response = await productService.InsertProduct(product);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(ProductCreateOrUpdateDto product)
        {
            var response = await productService.UpdateProduct(product);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(ProductCreateOrUpdateDto product)
        {
            if (product == null || !product.Id.HasValue) return BadRequest();

            var response = await productService.DeleteProduct(product.Id.Value);
            return Ok(response);

        }
    }
}