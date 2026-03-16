using KralInsaat.Common.DTOs.Faq;

namespace KralInsaat.Services.Interfaces
{
    public interface IFaqService
    {
        Task<List<GetFaqDTO>> GetAllFaqsAsync();
        Task<GetFaqDTO> GetFaqByIdAsync(int faqId);
        Task CreateFaqAsync(CreateFaqDTO model);
        Task UpdateFaqAsync(int faqId, UpdateFaqDTO model);
        Task DeleteFaqAsync(int faqId);
    }
} 
