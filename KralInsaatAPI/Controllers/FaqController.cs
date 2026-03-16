using KralInsaat.Common.DTOs.Faq;
using KralInsaat.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KralInsaat.API.Controllers
{
    public class FaqController : ControllerBase
    {
        private readonly IFaqService _faqservice;

        public FaqController(IFaqService faq)
        {
            _faqservice = faq;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFaqs()
        {
            var data = await _faqservice.GetAllFaqsAsync();

            return Ok(data);
        }

        [HttpGet("{faqId:int}")]
        public async Task<IActionResult> GetFaqById(int faqId)
        {
            var data = await _faqservice.GetFaqByIdAsync(faqId);

            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFaq([FromBody] CreateFaqDTO model)
        {
            await _faqservice.CreateFaqAsync(model);

            return NoContent();
        }

        [HttpPut("{faqId:int}")]
        public async Task<IActionResult> UpdateFaq(int faqId, [FromBody] UpdateFaqDTO model)
        {
            await _faqservice.UpdateFaqAsync(faqId, model);

            return NoContent();
        }

        [HttpDelete("{faqId:int}")]
        public async Task<IActionResult> DeleteFaq(int faqId)
        {
            await _faqservice.DeleteFaqAsync(faqId);

            return NoContent();
        }
    }
}
