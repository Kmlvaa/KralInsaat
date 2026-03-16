using AutoMapper;
using KralInsaat.Common.DTOs.Faq;
using KralInsaat.Common.Entities;
using KralInsaat.Db;
using Microsoft.EntityFrameworkCore;
using KralInsaat.Services.Interfaces;

namespace KralInsaat.Services.Implementations
{
    public class FaqService : IFaqService
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _appDbContext;
        public FaqService(IMapper mapper, AppDbContext appDbContext)
        {
            _mapper = mapper;
            _appDbContext = appDbContext;
        }

        public async Task<List<GetFaqDTO>> GetAllFaqsAsync()
        {
            var faqs = await _appDbContext.Faqs
                .AsNoTracking()
                .ToListAsync();

            var dto = _mapper.Map<List<GetFaqDTO>>(faqs);

            return dto;
        }

        public async Task<GetFaqDTO> GetFaqByIdAsync(int faqId)
        {
            var faq = await _appDbContext.Faqs
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.FaqId == faqId) ?? throw new Exception("Faq not found");

            var dto = _mapper.Map<GetFaqDTO>(faq);

            return dto;
        }

        public async Task CreateFaqAsync(CreateFaqDTO model)
        {
            var entity = _mapper.Map<FaqEntity>(model);

            _appDbContext.Faqs.Add(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task UpdateFaqAsync(int faqId, UpdateFaqDTO model)
        {
            var faq = await _appDbContext.Faqs
                .FirstOrDefaultAsync(x => x.FaqId == faqId) ?? throw new Exception("Faq not found");

            _mapper.Map(model, faq);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteFaqAsync(int faqId)
        {
            var faq = await _appDbContext.Faqs
                .FirstOrDefaultAsync(x => x.FaqId == faqId) ?? throw new Exception("Faq not found");

            _appDbContext.Faqs.Remove(faq);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
