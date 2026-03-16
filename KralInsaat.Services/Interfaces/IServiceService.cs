using KralInsaat.Common.DTOs.Service;

namespace KralInsaat.Services.Interfaces
{
    public interface IServiceService
    {
        Task<List<GetServiceDTO>> GetAllServicesAsync();
        Task<GetServiceDTO> GetServiceByIdAsync(int serviceId);
        Task CreateServiceAsync(CreateServiceDTO model);
        Task UpdateServiceAsync(int serviceId, UpdateServiceDTO model);
        Task DeleteServiceAsync(int serviceId);
    }
}
