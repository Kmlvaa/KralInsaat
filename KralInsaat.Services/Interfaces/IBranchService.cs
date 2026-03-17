using KralInsaat.Common.DTOs.Branch;

namespace KralInsaat.Services.Interfaces
{
    public interface IBranchService
    {
        Task<List<GetBranchDTO>> GetAllBranchsAsync();
        Task<GetBranchDTO> GetBranchByIdAsync(int branchId);
        Task CreateBranchAsync(CreateBranchDTO model);
        Task UpdateBranchAsync(int branchId, UpdateBranchDTO model);
        Task DeleteBranchAsync(int branchId);
    }
}
