using AutoMapper;
using KralInsaat.Common.DTOs.Category;
using KralInsaat.Common.Entities;
using KralInsaat.Db;
using KralInsaat.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KralInsaat.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper; 
        private readonly AppDbContext _appDbContext;
        public CategoryService(IMapper mapper, AppDbContext appDbContext)
        {
            _mapper = mapper;
            _appDbContext = appDbContext;
        }

        public async Task<List<GetCategoryDTO>> GetAllCategoriesAsync()
        {
            var categories = await _appDbContext.Categories
                .AsNoTracking() 
                .ToListAsync();

            var dto = _mapper.Map<List<GetCategoryDTO>>(categories);

            return dto;
        }

        public async Task<GetCategoryDTO> GetCategoryByIdAsync(int categoryId)
        {
            var category = await _appDbContext.Categories
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.CategoryId == categoryId) ?? throw new Exception("Service not found");

            var dto = _mapper.Map<GetCategoryDTO>(categoryId);

            return dto;
        }

        public async Task CreateCategoryAsync(CreateCategoryDTO model)
        {
            var entity = _mapper.Map<CategoryEntity>(model);

            _appDbContext.Categories.Add(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task UpdateCategoryAsync(int categoryId, UpdateCategoryDTO model)
        {
            var category = await _appDbContext.Categories
                .FirstOrDefaultAsync(x => x.CategoryId == categoryId) ?? throw new Exception("Service not found");

            _mapper.Map(model, category);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(int categoryId)
        {
            var category = await _appDbContext.Categories
                .FirstOrDefaultAsync(x => x.CategoryId == categoryId) ?? throw new Exception("Service not found");

            _appDbContext.Categories.Remove(category);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
