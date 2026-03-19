using AutoMapper;
using KralInsaat.Common.DTOs.Branch;
using KralInsaat.Common.Entities;
using KralInsaat.Db;
using Microsoft.EntityFrameworkCore;
using KralInsaat.Services.Interfaces;
using KralInsaat.Common.Exceptions;

namespace KralInsaat.Services.Implementations
{
    public class BranchService : IBranchService
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _appDbContext;
        public BranchService(IMapper mapper, AppDbContext appDbContext)
        {
            _mapper = mapper;
            _appDbContext = appDbContext;
        }

        public async Task<List<GetBranchDTO>> GetAllBranchsAsync()
        {
            var branches = await _appDbContext.CompanyBranches
                .AsNoTracking()
                .ToListAsync();

            var dto = _mapper.Map<List<GetBranchDTO>>(branches);

            return dto;
        }
           
        public async Task<GetBranchDTO> GetBranchByIdAsync(int branchId)
        {
            var entity = await _appDbContext.CompanyBranches
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.BranchId == branchId) ?? throw new NotFoundException("Branch not found");

            var dto = _mapper.Map<GetBranchDTO>(entity);

            return dto;
        }

        public async Task CreateBranchAsync(CreateBranchDTO model)
        {
            bool isCompanyExist = await _appDbContext.Companies
                .AnyAsync(x => x.CompanyId == model.CompanyId);

            if (!isCompanyExist)
                throw new NotFoundException($"Company with the id {model.CompanyId} is not found.");

            var entity = _mapper.Map<BranchEntity>(model);

            _appDbContext.CompanyBranches.Add(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task UpdateBranchAsync(int branchId, UpdateBranchDTO model)
        {
            bool isCompanyExist = await _appDbContext.Companies
                .AnyAsync(x => x.CompanyId == model.CompanyId);

            if (!isCompanyExist)
                throw new NotFoundException($"Company with the id {model.CompanyId} is not found.");

            var branch = await _appDbContext.CompanyBranches
                .FirstOrDefaultAsync(x => x.BranchId == branchId) ?? throw new NotFoundException("Branch not found");

            _mapper.Map(model, branch);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteBranchAsync(int branchId)
        {
            var branch = await _appDbContext.CompanyBranches
                .FirstOrDefaultAsync(x => x.BranchId == branchId) ?? throw new NotFoundException("Branch not found");

            _appDbContext.CompanyBranches.Remove(branch);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
