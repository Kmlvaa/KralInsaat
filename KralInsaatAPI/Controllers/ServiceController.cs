using KralInsaat.API.Controllers.Base;
using KralInsaat.Common.DTOs.Service;
using KralInsaat.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KralInsaat.API.Controllers
{
    public class ServiceController : BaseController
    {
        private readonly IServiceService _service;

        public ServiceController(IServiceService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllServices()
        {
            var data = await _service.GetAllServicesAsync();

            return Ok(data);
        }

        [HttpGet("{serviceId:int}")]
        public async Task<IActionResult> GetServiceById(int serviceId)
        {
            var data = await _service.GetServiceByIdAsync(serviceId);

            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateService([FromBody] CreateServiceDTO model) 
        {
            await _service.CreateServiceAsync(model);

            return NoContent();
        }

        [HttpPut("{serviceId:int}")]
        public async Task<IActionResult> UpdateService(int serviceId, [FromBody] UpdateServiceDTO model)
        {
            await _service.UpdateServiceAsync(serviceId, model);

            return NoContent();
        }

        [HttpDelete("{serviceId:int}")]
        public async Task<IActionResult> DeleteService(int serviceId)
        {
            await _service.DeleteServiceAsync(serviceId);

            return NoContent();
        }
    }
}
