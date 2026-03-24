using AutoMapper;
using KralInsaat.Common.DTOs.Pagination;
using KralInsaat.Common.Entities.Base;
using KralInsaat.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KralInsaat.Services.Implementations
{
    public class PaginationService : IPaginationService
    {
        private readonly IMapper _mapper;
        public PaginationService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<PaginationResultDTO<TDto>> GetPagedResultAsync<TEntity, TDto>(
            IQueryable<TEntity> query,
            int pageNumber,
            int pageSize)
            where TEntity : IBaseEntity
        {
            var totalCount = await query.CountAsync();

            var records = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PaginationResultDTO<TDto>
            {
                Records = records.Select(x => _mapper.Map<TDto>(x)),
                TotalCount = totalCount,
                CurrentPage = pageNumber,
                PageSize = pageSize
            };
        }
    }
}