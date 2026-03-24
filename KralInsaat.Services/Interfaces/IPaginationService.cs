using KralInsaat.Common.DTOs.Pagination;
using KralInsaat.Common.Entities.Base;

namespace KralInsaat.Services.Interfaces
{
    public interface IPaginationService
    {
        Task<PaginationResultDTO<TDto>> GetPagedResultAsync<TEntity, TDto>(
           IQueryable<TEntity> query,
           int pageNumber,
           int pageSize)
           where TEntity : IBaseEntity;
    }
}
