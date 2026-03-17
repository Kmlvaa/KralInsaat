using KralInsaat.API.Controllers.Base;
using KralInsaat.Common.DTOs.Brand;
using KralInsaat.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KralInsaat.API.Controllers
{
    public class BrandController : BaseController
    {
        private readonly IBrandService _brandservice;

        public BrandController(IBrandService brand)
        {
            _brandservice = brand;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBrands()
        {
            var data = await _brandservice.GetAllBrandsAsync();

            return Ok(data);
        }

        [HttpGet("{brandId:int}")]
        public async Task<IActionResult> GetBrandById(int brandId)
        {
            var data = await _brandservice.GetBrandByIdAsync(brandId);

            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrand([FromBody] CreateBrandDTO model)
        {
            await _brandservice.CreateBrandAsync(model);

            return NoContent();
        }

        [HttpPut("{brandId:int}")]
        public async Task<IActionResult> UpdateBrand(int brandId, [FromBody] UpdateBrandDTO model)
        {
            await _brandservice.UpdateBrandAsync(brandId, model);

            return NoContent();
        }

        [HttpDelete("{brandId:int}")]
        public async Task<IActionResult> DeleteBrand(int brandId)
        {
            await _brandservice.DeleteBrandAsync(brandId);

            return NoContent();
        }
    }
}
