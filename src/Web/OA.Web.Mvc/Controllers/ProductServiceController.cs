using Microsoft.AspNetCore.Mvc;
using OA.Application.Dtos;
using OA.Application.Interfaces;

namespace OA.Web.Mvc.Controllers
{
    public class ProductServiceController : Controller
    {
        private readonly IProductService _productService;

        public ProductServiceController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: ProductServiceController
        public async Task<ActionResult> Index()
        {
            var products = await _productService.GetAllProducts();
            return View(products);
        }

        public async Task<PartialViewResult> ViewProduct(Guid id)
        {
            var product = await _productService.GetProduct(id);
            return PartialView("_ViewProduct", product);
        }

        [HttpGet]
        public PartialViewResult AddProduct()
        {
            var product = new ProductCreateOrUpdateDto();
            return PartialView("_AddProduct", product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddProduct(ProductCreateOrUpdateDto product)
        {
            try
            {
                var insertedId = await _productService.InsertProduct(product);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return PartialView("_AddProduct", product);
            }
        }

        public async Task<PartialViewResult> EditProduct(Guid? id)
        {
            var productDto = new ProductCreateOrUpdateDto();
            if (id.HasValue && id != Guid.Empty)
            {
                var product = await _productService.GetProduct(id.Value);
                productDto.Name = product.Name;
                productDto.Price = product.Price;
            }
            return PartialView("_EditProduct", productDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditProduct(ProductCreateOrUpdateDto product)
        {
            var updated = await _productService.UpdateProduct(product);
            if (updated)
            {
                return RedirectToAction(nameof(Index));
            }

            return PartialView("_EditProduct", product);
        }

        [HttpGet]
        public async Task<PartialViewResult> DeleteProduct(Guid id)
        {
            var product = await _productService.GetProduct(id);
            string name = $"{product.Name}";
            return PartialView("_DeleteProduct", name);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteProductPost(Guid id)
        {
            await _productService.DeleteProduct(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
