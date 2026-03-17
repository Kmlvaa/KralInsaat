using KralInsaat.API.Controllers.Base;
using KralInsaat.Common.DTOs.Brand;
using KralInsaat.Common.DTOs.Company;
using KralInsaat.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KralInsaat.API.Controllers
{
    public class CompanyController : BaseController
    {
        private readonly ICompanyService _companyservice;

        public CompanyController(ICompanyService company)
        {
            _companyservice = company;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCompanies()
        {
            var data = await _companyservice.GetAllCompaniesAsync();

            return Ok(data);
        }

        [HttpGet("{companyId:int}")]
        public async Task<IActionResult> GetCompanyById(int companyId)
        {
            var data = await _companyservice.GetCompanyByIdAsync(companyId);

            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany([FromBody] CreateCompanyDTO model)
        {
            await _companyservice.CreateCompanyAsync(model);

            return NoContent();
        }

        [HttpPut("{companyId:int}")]
        public async Task<IActionResult> UpdateCompany(int companyId, [FromBody] UpdateCompanyDTO model)
        {
            await _companyservice.UpdateCompanyAsync(companyId, model);

            return NoContent();
        }

        [HttpDelete("{companyId:int}")]
        public async Task<IActionResult> DeleteCompany(int companyId)
        {
            await _companyservice.DeleteCompanyAsync(companyId);

            return NoContent();
        }
    }
} 
