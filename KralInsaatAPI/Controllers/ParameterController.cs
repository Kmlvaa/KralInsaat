using KralInsaat.API.Controllers.Base;
using KralInsaat.Common.DTOs.CategoryParameter;
using KralInsaat.Common.DTOs.Parameter;
using KralInsaat.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KralInsaat.API.Controllers
{
    public class ParameterController : BaseController
    {
        private readonly IParameterService _parameterservice;

        public ParameterController(IParameterService parameter)
        {
            _parameterservice = parameter;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllParameteres()
        {
            var data = await _parameterservice.GetAllParametersAsync();

            return Ok(data);
        }

        [HttpGet("{prameterId:int}")]
        public async Task<IActionResult> GetParameterById(int prameterId)
        {
            var data = await _parameterservice.GetParameterByIdAsync(prameterId);

            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateParameter([FromBody] CreateParameterDTO model)
        {
            await _parameterservice.CreateParameterAsync(model);

            return NoContent();
        }

        [HttpPut("{prameterId:int}")]
        public async Task<IActionResult> UpdateParameter(int prameterId, [FromBody] UpdateParameterDTO model)
        {
            await _parameterservice.UpdateParameterAsync(prameterId, model);

            return NoContent();
        }

        [HttpDelete("{prameterId:int}")]
        public async Task<IActionResult> DeleteParameter(int prameterId)
        {
            await _parameterservice.DeleteParameterAsync(prameterId);

            return NoContent();
        }

        [HttpPost("assing-parameter-to-category")]
        public async Task<IActionResult> AssignParameterToCategory([FromBody] CreateCategoryParameterDTO model)
        {
            await _parameterservice.AddParameterToCategoryAsync(model);

            return NoContent();
        }

        [HttpGet("category{categoryId:int}/parameters")]
        public async Task<IActionResult> GetCategoryParameters(int categoryId)
        {
            var dto = await _parameterservice.GetCategoryParametersAsync(categoryId);
            
            return Ok(dto);
        }
    }
}
