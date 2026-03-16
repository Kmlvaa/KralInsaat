using AutoMapper;
using KralInsaat.Common.DTOs.Terms;
using KralInsaat.Common.Entities;
using KralInsaat.Db;
using Microsoft.EntityFrameworkCore;
using KralInsaat.Services.Interfaces;

namespace KralInsaat.Services.Implementations
{
    public class TermsService : ITermsService
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _appDbContext;
        public TermsService(IMapper mapper, AppDbContext appDbContext)
        {
            _mapper = mapper;
            _appDbContext = appDbContext;
        }

        public async Task<List<GetTermsDTO>> GetAllTermsAsync()
        {
            var terms = await _appDbContext.Terms 
                .AsNoTracking()
                .ToListAsync();

            var dto = _mapper.Map<List<GetTermsDTO>>(terms);

            return dto;
        }

        public async Task<GetTermsDTO> GetTermsByIdAsync(int termsId)
        {
            var terms = await _appDbContext.Terms
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.TermsId == termsId) ?? throw new Exception("Terms not found");

            var dto = _mapper.Map<GetTermsDTO>(terms);

            return dto;
        }

        public async Task CreateTermsAsync(CreateTermsDTO model)
        {
            var entity = _mapper.Map<TermsEntity>(model);

            _appDbContext.Terms.Add(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task UpdateTermsAsync(int termsId, UpdateTermsDTO model)
        {
            var terms = await _appDbContext.Terms
                .FirstOrDefaultAsync(x => x.TermsId == termsId) ?? throw new Exception("Terms not found");

            _mapper.Map(model, terms);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteTermsAsync(int termsId)
        {
            var terms = await _appDbContext.Terms
                .FirstOrDefaultAsync(x => x.TermsId == termsId) ?? throw new Exception("Terms not found");

            _appDbContext.Terms.Remove(terms);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
