using AutoMapper;
using KralInsaat.Common.DTOs.Company;
using KralInsaat.Common.Entities;
using KralInsaat.Db;
using Microsoft.EntityFrameworkCore;
using KralInsaat.Services.Interfaces;

namespace KralInsaat.Services.Implementations
{
    public class CompanyService : ICompanyService
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _appDbContext;
        public CompanyService(IMapper mapper, AppDbContext appDbContext)
        {
            _mapper = mapper;
            _appDbContext = appDbContext;
        }

        public async Task<List<GetCompanyDTO>> GetAllCompaniesAsync()
        { 
            var companies = await _appDbContext.Companies
                .AsNoTracking() 
                .ToListAsync();

            var dto = _mapper.Map<List<GetCompanyDTO>>(companies);

            return dto;
        }

        public async Task<GetCompanyDTO> GetCompanyByIdAsync(int companyId)
        {
            var company = await _appDbContext.Companies
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.CompanyId == companyId) ?? throw new Exception("Company not found");

            var dto = _mapper.Map<GetCompanyDTO>(company);

            return dto;
        }

        public async Task CreateCompanyAsync(CreateCompanyDTO model)
        {
            var entity = _mapper.Map<CompanyEntity>(model);

            _appDbContext.Companies.Add(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task UpdateCompanyAsync(int companyId, UpdateCompanyDTO model)
        {
            var company = await _appDbContext.Companies
                .FirstOrDefaultAsync(x => x.CompanyId == companyId) ?? throw new Exception("Company not found");

            _mapper.Map(model, company);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteCompanyAsync(int companyId)
        {
            var company = await _appDbContext.Companies
                .FirstOrDefaultAsync(x => x.CompanyId == companyId) ?? throw new Exception("Company not found");

            _appDbContext.Companies.Remove(company);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
