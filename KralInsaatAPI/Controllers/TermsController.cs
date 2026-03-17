using KralInsaat.API.Controllers.Base;
using KralInsaat.Common.DTOs.Terms;
using KralInsaat.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KralInsaat.API.Controllers
{
    public class TermsController : BaseController
    {
        private readonly ITermsService _termsService;

        public TermsController(ITermsService terms)
        {
            _termsService = terms;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTermss()
        {
            var data = await _termsService.GetAllTermsAsync();

            return Ok(data);
        }

        [HttpGet("{termsId:int}")]
        public async Task<IActionResult> GetTermsById(int termsId)
        {
            var data = await _termsService.GetTermsByIdAsync(termsId);

            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTerms([FromBody] CreateTermsDTO model)
        {
            await _termsService.CreateTermsAsync(model);

            return NoContent();
        }

        [HttpPut("{termsId:int}")]
        public async Task<IActionResult> UpdateTerms(int termsId, [FromBody] UpdateTermsDTO model)
        {
            await _termsService.UpdateTermsAsync(termsId, model);

            return NoContent();
        }

        [HttpDelete("{termsId:int}")]
        public async Task<IActionResult> DeleteTerms(int termsId)
        {
            await _termsService.DeleteTermsAsync(termsId);

            return NoContent();
        }
    }
}
