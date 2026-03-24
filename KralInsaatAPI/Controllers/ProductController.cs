using KralInsaat.API.Controllers.Base;
using KralInsaat.API.DTO;
using KralInsaat.Common.DTOs.Product;
using KralInsaat.Common.DTOs.ProductImages;
using KralInsaat.Common.DTOs.ProductParameter;
using KralInsaat.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KralInsaat.API.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductService _productservice;
        private readonly IWebHostEnvironment _env;

        public ProductController(IProductService product, IWebHostEnvironment env)
        {
            _productservice = product;
            _env = env;
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
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> CreateProduct([FromForm] CreateProductRequestDTO model)
        {
            var productDTO = new CreateProductDTO
            {
                ProductName = model.ProductName,
                ProductDescription = model.ProductDescription,
                ProductPrice = model.ProductPrice,
                ProductSalePrice = model.ProductSalePrice,
                BrandId = model.BrandId,
                CategoryId = model.CategoryId,
            };

            var imageDtos = model.ProductImages?.Select((file, index) => new FileUploadDTO
            {
                FileName = file.FileName,
                ContentType = file.ContentType,
                Length = file.Length,
                Content = file.OpenReadStream(),
                IsCoverImage = model.CoverIndex == index
            }).ToList();


            await _productservice.CreateProductAsync(productDTO, imageDtos, _env.WebRootPath);

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
