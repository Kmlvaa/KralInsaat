using KralInsaat.Common.DTOs.SocialMediaAccount;

namespace KralInsaat.Services.Interfaces
{
    public interface ISocialMediaAccountService
    {
        Task<List<GetSocialMediaAccountDTO>> GetAllSocialMediaAccountsAsync();
        Task<GetSocialMediaAccountDTO> GetSocialMediaAccountByIdAsync(int accountId);
        Task CreateSocialMediaAccountAsync(CreateSocialMediaAccountDTO model);
        Task UpdateSocialMediaAccountAsync(int accountId, UpdateSocialMediaAccountDTO model);
        Task DeleteSocialMediaAccountAsync(int accountId);
    }
}
