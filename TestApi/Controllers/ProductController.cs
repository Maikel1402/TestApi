using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestCore.Dto.Request;
using TestCore.Interfaces;
using TestCore.Validator.ProductValidator;

namespace TestApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService _productInterface;
        private CreateProductValidator _productValidator;
        private UpdateProductValidator _updateProductValidator;
        private DeleteProductValidator _deleteProductValidator;

        public ProductController(IProductService productInterface, CreateProductValidator productValidator, UpdateProductValidator updateProductValidator
            ,DeleteProductValidator deleteProductValidator)
        {
            _productInterface = productInterface;
            _productValidator = productValidator;
            _updateProductValidator = updateProductValidator;
            _deleteProductValidator = deleteProductValidator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() { 
            
            var product = await _productInterface.GetProducts();
            return Ok(product);
        
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productInterface.GetProductById(id);
            if (product == null) return NoContent();
            return Ok(product);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductRequest product) {
            var validationResult = _productValidator.Validate(product);
            if(!validationResult.IsValid) 
                return BadRequest(validationResult.Errors);

            await _productInterface.Create(product);
            return Ok(new {message = "Product Created"});       
        }
        [HttpPut]
        public async Task<IActionResult> Update(ProductRequest product) {

            var validationResult = await _updateProductValidator.ValidateAsync(product);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            await _productInterface.Update(product);
            return Ok(new { message = "Product Updated" });
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = new ProductRequest { Id = id };
            var validationResult = await _deleteProductValidator.ValidateAsync(product);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            await _productInterface.Delete(product.Id);
            return Ok(new { message = "Product deleted" });
        }
    }
}
