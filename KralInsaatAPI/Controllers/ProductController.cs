using KralInsaat.API.Controllers.Base;
using KralInsaat.Common.DTOs.Product;
using KralInsaat.Common.DTOs.ProductParameter;
using KralInsaat.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KralInsaat.API.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductService _productservice;

        public ProductController(IProductService product)
        {
            _productservice = product;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductes()
        {
            var data = await _productservice.GetAllProductsAsync();

            return Ok(data);
        }

        [HttpGet("{productId:int}")]
        public async Task<IActionResult> GetProductById(int productId)
        {
            var data = await _productservice.GetProductByIdAsync(productId);

            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductDTO model)
        {
            await _productservice.CreateProductAsync(model);

            return NoContent();
        }

        [HttpPut("{productId:int}")]
        public async Task<IActionResult> UpdateProduct(int productId, [FromBody] UpdateProductDTO model)
        {
            await _productservice.UpdateProductAsync(productId, model);

            return NoContent();
        }

        [HttpDelete("{productId:int}")]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            await _productservice.DeleteProductAsync(productId);

            return NoContent();
        }

        [HttpGet("{productId:int}/parameters")]
        public async Task<IActionResult> GetProductParameters(int productId)
        {
            var dto = await _productservice.GetProductParametersAsync(productId);

            return Ok(dto);
        }

        [HttpPost("{productId:int}/parameters")]
        public async Task<IActionResult> SetProductParameters(int productId, SetProductParameterDTO model)
        {
            await _productservice.SetProductParametersAsync(productId, model);

            return NoContent();
        }
    }
}
