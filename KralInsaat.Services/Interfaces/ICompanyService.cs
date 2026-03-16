using KralInsaat.Common.DTOs.Brand;
using KralInsaat.Common.DTOs.Company;

namespace KralInsaat.Services.Interfaces
{
    public interface ICompanyService
    {
        Task<List<GetCompanyDTO>> GetAllCompaniesAsync();
        Task<GetCompanyDTO> GetCompanyByIdAsync(int companyId);
        Task CreateCompanyAsync(CreateCompanyDTO model);
        Task UpdateCompanyAsync(int companyId, UpdateCompanyDTO model);
        Task DeleteCompanyAsync(int companyId);
    }
}
 