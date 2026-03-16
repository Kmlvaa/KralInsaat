using KralInsaat.Common.DTOs.Brand;
using KralInsaat.Common.DTOs.Category;
using KralInsaat.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KralInsaat.API.Controllers
{
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryservice;

        public CategoryController(ICategoryService category)
        {
            _categoryservice = category;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var data = await _categoryservice.GetAllCategoriesAsync();

            return Ok(data);
        }

        [HttpGet("{categoryId:int}")]
        public async Task<IActionResult> GetCategoryById(int categoryId)
        {
            var data = await _categoryservice.GetCategoryByIdAsync(categoryId);

            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDTO model)
        {
            await _categoryservice.CreateCategoryAsync(model);

            return NoContent();
        }

        [HttpPut("{categoryId:int}")]
        public async Task<IActionResult> UpdateCategory(int categoryId, [FromBody] UpdateCategoryDTO model)
        {
            await _categoryservice.UpdateCategoryAsync(categoryId, model);

            return NoContent();
        }

        [HttpDelete("{categoryId:int}")]
        public async Task<IActionResult> DeleteCategory(int categoryId)
        {
            await _categoryservice.DeleteCategoryAsync(categoryId);

            return NoContent();
        }
    }
}
