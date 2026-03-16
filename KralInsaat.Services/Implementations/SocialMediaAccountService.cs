using AutoMapper;
using KralInsaat.Common.DTOs.SocialMediaAccount;
using KralInsaat.Common.Entities;
using KralInsaat.Db;
using Microsoft.EntityFrameworkCore;
using KralInsaat.Services.Interfaces;

namespace KralInsaat.Services.Implementations
{
    public class SocialMediaAccountService : ISocialMediaAccountService
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _appDbContext;
        public SocialMediaAccountService(IMapper mapper, AppDbContext appDbContext)
        {
            _mapper = mapper;
            _appDbContext = appDbContext;
        }

        public async Task<List<GetSocialMediaAccountDTO>> GetAllSocialMediaAccountsAsync()
        {
            var socialMediaAccounts = await _appDbContext.SocialMediaAccounts
                .AsNoTracking()
                .ToListAsync();

            var dto = _mapper.Map<List<GetSocialMediaAccountDTO>>(socialMediaAccounts);

            return dto;
        }

        public async Task<GetSocialMediaAccountDTO> GetSocialMediaAccountByIdAsync(int accountId)
        {
            var socialMediaAccounts = await _appDbContext.SocialMediaAccounts
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.SocialMediaAccountId == accountId) ?? throw new Exception("SocialMediaAccount not found");

            var dto = _mapper.Map<GetSocialMediaAccountDTO>(socialMediaAccounts);

            return dto;
        }

        public async Task CreateSocialMediaAccountAsync(CreateSocialMediaAccountDTO model)
        {
            var entity = _mapper.Map<SocialMediaAccountEntity>(model);

            _appDbContext.SocialMediaAccounts.Add(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task UpdateSocialMediaAccountAsync(int accountId, UpdateSocialMediaAccountDTO model)
        {
            var socialMediaAccount = await _appDbContext.SocialMediaAccounts
                .FirstOrDefaultAsync(x => x.SocialMediaAccountId == accountId) ?? throw new Exception("SocialMediaAccount not found");

            _mapper.Map(model, socialMediaAccount);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteSocialMediaAccountAsync(int accountId)
        {
            var socialMediaAccount = await _appDbContext.SocialMediaAccounts
                .FirstOrDefaultAsync(x => x.SocialMediaAccountId == accountId) ?? throw new Exception("SocialMediaAccount not found");

            _appDbContext.SocialMediaAccounts.Remove(socialMediaAccount);
            await _appDbContext.SaveChangesAsync();
        }
    }
} 
