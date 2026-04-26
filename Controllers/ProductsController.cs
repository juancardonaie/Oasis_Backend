using Microsoft.AspNetCore.Mvc;
using oasis_backend.Models;
using oasis_backend.Service;

namespace oasis_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var products = await _productService.GetByIdAsync(id);
            if (products == null) return NotFound();

            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Product product)
        {
            var id = await _productService.CreateAsync(product);

            return Ok(new {id});
        }

        [HttpPut]
        public async Task<IActionResult> Update(string id, [FromBody] Product product)
        {
            await _productService.UpdateAsync(id, product);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult>Delete( string id)
        {
            await _productService.DeleteAsync(id);
            return Ok();
        }

    }
}
