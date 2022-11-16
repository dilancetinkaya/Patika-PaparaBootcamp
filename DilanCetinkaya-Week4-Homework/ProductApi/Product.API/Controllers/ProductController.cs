using Microsoft.AspNetCore.Mvc;
using Product.Data.Dtos;
using Product.Service.Abstracts;
using System.Threading.Tasks;

namespace Product.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("List")]
        public async Task<IActionResult> GetProducts()
        {
            var productList = await _productService.GetAllAsync();
            return Ok(productList);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productService.GetAsync(id);
            return Ok(product);

        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductDto productDto)
        {
            await _productService.AddAsync(productDto);
            return Ok();

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEProduct(ProductDto productDto, int id)
        {

            await _productService.Update(productDto, id);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productService.Delete(id);
            return Ok();
        }
    }
}
