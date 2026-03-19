using AutoMapper;
using AutoMapper.QueryableExtensions;
using KralInsaat.Common.DTOs.CategoryParameter;
using KralInsaat.Common.DTOs.Parameter;
using KralInsaat.Common.Entities;
using KralInsaat.Common.Exceptions;
using KralInsaat.Db;
using KralInsaat.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KralInsaat.Services.Implementations
{
    public class ParameterService : IParameterService
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _appDbContext;
        public ParameterService(IMapper mapper, AppDbContext appDbContext)
        {
            _mapper = mapper;
            _appDbContext = appDbContext;
        }

        public async Task<List<GetParameterDTO>> GetAllParametersAsync()
        {
            var parameteres = await _appDbContext.Parameters
                .AsNoTracking()
                .ToListAsync();

            var dto = _mapper.Map<List<GetParameterDTO>>(parameteres);

            return dto;
        }

        public async Task<GetParameterDTO> GetParameterByIdAsync(int parameterId)
        {
            var entity = await _appDbContext.Parameters
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.ParameterId == parameterId) ?? throw new NotFoundException("Parameter not found");

            var dto = _mapper.Map<GetParameterDTO>(entity);

            return dto;
        }

        public async Task CreateParameterAsync(CreateParameterDTO model)
        {
            var entity = _mapper.Map<ParameterEntity>(model);

            _appDbContext.Parameters.Add(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task UpdateParameterAsync(int parameterId, UpdateParameterDTO model)
        {
            var entity = await _appDbContext.Parameters
                .FirstOrDefaultAsync(x => x.ParameterId == parameterId) ?? throw new NotFoundException("Parameter not found");

            _mapper.Map(model, entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteParameterAsync(int parameterId)
        {
            var entity = await _appDbContext.Parameters
                .FirstOrDefaultAsync(x => x.ParameterId == parameterId) ?? throw new NotFoundException("Parameter not found");

            _appDbContext.Parameters.Remove(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<List<GetParameterDTO>> GetCategoryParametersAsync(int categoryId)
        {
            bool isCategoryExist = await _appDbContext.Categories
               .AnyAsync(x => x.CategoryId == categoryId); 

            if (!isCategoryExist)
                throw new NotFoundException($"Category with the id {categoryId} is not found.");

            return await _appDbContext.CategoryParameters
               .Where(cp => cp.CategoryId == categoryId)
               .ProjectTo<GetParameterDTO>(_mapper.ConfigurationProvider)
               .AsNoTracking()
               .ToListAsync();
        }
         
        public async Task AddParameterToCategoryAsync(CreateCategoryParameterDTO model)
        {
            bool isCategoryExist = await _appDbContext.Categories
               .AnyAsync(x => x.CategoryId == model.CategoryId); 

            if (!isCategoryExist)
                throw new NotFoundException($"Category with the id {model.CategoryId} is not found.");

            bool isParameterExist = await _appDbContext.Parameters
               .AnyAsync(x => x.ParameterId == model.ParameterId);

            if (!isParameterExist)
                throw new NotFoundException($"Parameter with the id {model.ParameterId} is not found.");

            var exists = await _appDbContext.CategoryParameters
                .AnyAsync(x => x.CategoryId == model.CategoryId && x.ParameterId == model.ParameterId);

            if (exists)
                return;

            var dto = _mapper.Map<CategoryParameterEntity>(model);

            _appDbContext.CategoryParameters.Add(dto);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
