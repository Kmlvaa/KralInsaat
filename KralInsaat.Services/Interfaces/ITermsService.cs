using KralInsaat.Common.DTOs.Terms;

namespace KralInsaat.Services.Interfaces
{
    public interface ITermsService
    {
        Task<List<GetTermsDTO>> GetAllTermsAsync();
        Task<GetTermsDTO> GetTermsByIdAsync(int termsId);
        Task CreateTermsAsync(CreateTermsDTO model);
        Task UpdateTermsAsync(int termsId, UpdateTermsDTO model);
        Task DeleteTermsAsync(int termsId);
    }
} 
