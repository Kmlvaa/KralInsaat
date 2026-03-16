using KralInsaat.Common.DTOs.Category;

namespace KralInsaat.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<List<GetCategoryDTO>> GetAllCategoriesAsync();
        Task<GetCategoryDTO> GetCategoryByIdAsync(int categoryId);
        Task CreateCategoryAsync(CreateCategoryDTO model);
        Task UpdateCategoryAsync(int categoryId, UpdateCategoryDTO model);
        Task DeleteCategoryAsync(int categoryId);
    }
}
