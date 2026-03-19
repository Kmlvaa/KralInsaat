using KralInsaat.Common.DTOs.CategoryParameter;
using KralInsaat.Common.DTOs.Parameter;

namespace KralInsaat.Services.Interfaces
{
    public interface IParameterService
    {
        Task<List<GetParameterDTO>> GetAllParametersAsync();
        Task<GetParameterDTO> GetParameterByIdAsync(int parameterId);
        Task CreateParameterAsync(CreateParameterDTO model);
        Task UpdateParameterAsync(int parameterId, UpdateParameterDTO model);
        Task DeleteParameterAsync(int parameterId);
        Task<List<GetParameterDTO>> GetCategoryParametersAsync(int categoryId);
        Task AddParameterToCategoryAsync(CreateCategoryParameterDTO model);
    }
}
  