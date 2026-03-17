using KralInsaat.API.Controllers.Base;
using KralInsaat.Common.DTOs.SocialMediaAccount;
using KralInsaat.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KralInsaat.API.Controllers
{
    public class SocialMediaAccountController : BaseController
    {
        private readonly ISocialMediaAccountService _socialMediaAccountservice;

        public SocialMediaAccountController(ISocialMediaAccountService socialMediaAccount)
        {
            _socialMediaAccountservice = socialMediaAccount;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSocialMediaAccounts()
        {
            var data = await _socialMediaAccountservice.GetAllSocialMediaAccountsAsync();

            return Ok(data);
        }

        [HttpGet("{accountId:int}")]
        public async Task<IActionResult> GetSocialMediaAccountById(int accountId)
        {
            var data = await _socialMediaAccountservice.GetSocialMediaAccountByIdAsync(accountId);

            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSocialMediaAccount([FromBody] CreateSocialMediaAccountDTO model)
        {
            await _socialMediaAccountservice.CreateSocialMediaAccountAsync(model);

            return NoContent();
        }

        [HttpPut("{accountId:int}")]
        public async Task<IActionResult> UpdateSocialMediaAccount(int accountId, [FromBody] UpdateSocialMediaAccountDTO model)
        {
            await _socialMediaAccountservice.UpdateSocialMediaAccountAsync(accountId, model);

            return NoContent();
        }

        [HttpDelete("{accountId:int}")]
        public async Task<IActionResult> DeleteSocialMediaAccount(int accountId)
        {
            await _socialMediaAccountservice.DeleteSocialMediaAccountAsync(accountId);

            return NoContent();
        }
    }
}
