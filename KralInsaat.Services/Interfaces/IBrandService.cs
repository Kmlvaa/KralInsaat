using KralInsaat.Common.DTOs.Brand;

namespace KralInsaat.Services.Interfaces
{
    public interface IBrandService
    {
        Task<List<GetBrandDTO>> GetAllBrandsAsync();
        Task<GetBrandDTO> GetBrandByIdAsync(int serviceId);
        Task CreateBrandAsync(CreateBrandDTO model);
        Task UpdateBrandAsync(int serviceId, UpdateBrandDTO model);
        Task DeleteBrandAsync(int serviceId);
    }
}
 