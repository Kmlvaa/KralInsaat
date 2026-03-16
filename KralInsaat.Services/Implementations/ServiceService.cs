using AutoMapper;
using KralInsaat.Common.DTOs.Service;
using KralInsaat.Common.Entities;
using KralInsaat.Db;
using KralInsaat.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KralInsaat.Services.Implementations
{
    public class ServiceService : IServiceService
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _appDbContext;
        public ServiceService(IMapper mapper, AppDbContext appDbContext) 
        { 
            _mapper = mapper;
            _appDbContext = appDbContext;
        }

        public async Task<List<GetServiceDTO>> GetAllServicesAsync()
        {
            var services = await _appDbContext.Services
                .AsNoTracking()
                .ToListAsync();

            var dto = _mapper.Map<List<GetServiceDTO>>(services);

            return dto;
        }

        public async Task<GetServiceDTO> GetServiceByIdAsync(int serviceId)
        {
            var service = await _appDbContext.Services
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.ServiceId == serviceId) ?? throw new Exception("Service not found");

            var dto = _mapper.Map<GetServiceDTO>(service);

            return dto;
        }

        public async Task CreateServiceAsync(CreateServiceDTO model)
        {
            var entity = _mapper.Map<ServiceEntity>(model);

            _appDbContext.Services.Add(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task UpdateServiceAsync(int serviceId, UpdateServiceDTO model)
        {
            var service = await _appDbContext.Services
                .FirstOrDefaultAsync(x => x.ServiceId == serviceId) ?? throw new Exception("Service not found");

            _mapper.Map(model, service);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteServiceAsync(int serviceId)
        {
            var service = await _appDbContext.Services
                .FirstOrDefaultAsync(x => x.ServiceId == serviceId) ?? throw new Exception("Service not found");

            _appDbContext.Services.Remove(service);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
