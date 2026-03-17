using AutoMapper;
using KralInsaat.Common.DTOs.Brand;
using KralInsaat.Common.Entities;
using KralInsaat.Common.Exceptions;
using KralInsaat.Db;
using KralInsaat.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KralInsaat.Services.Implementations
{
    public class BrandService : IBrandService
    { 
        private readonly IMapper _mapper;
        private readonly AppDbContext _appDbContext;
        public BrandService(IMapper mapper, AppDbContext appDbContext)
        {
            _mapper = mapper;
            _appDbContext = appDbContext;
        } 

        public async Task<List<GetBrandDTO>> GetAllBrandsAsync()
        {
            var brands = await _appDbContext.Brands
                .AsNoTracking()
                .ToListAsync();

            var dto = _mapper.Map<List<GetBrandDTO>>(brands);

            return dto;
        }

        public async Task<GetBrandDTO> GetBrandByIdAsync(int brandId)
        {
            var brand = await _appDbContext.Brands
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.BrandId == brandId) ?? throw new NotFoundException("Brand not found");

            var dto = _mapper.Map<GetBrandDTO>(brand);

            return dto;
        }

        public async Task CreateBrandAsync(CreateBrandDTO model)
        {
            var entity = _mapper.Map<BrandEntity>(model);

            _appDbContext.Brands.Add(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task UpdateBrandAsync(int brandId, UpdateBrandDTO model)
        {
            var brand = await _appDbContext.Brands
                .FirstOrDefaultAsync(x => x.BrandId == brandId) ?? throw new NotFoundException("Brand not found");

            _mapper.Map(model, brand);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteBrandAsync(int brandId)
        {
            var brand = await _appDbContext.Brands
                .FirstOrDefaultAsync(x => x.BrandId == brandId) ?? throw new NotFoundException("Brand not found");

            _appDbContext.Brands.Remove(brand);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
