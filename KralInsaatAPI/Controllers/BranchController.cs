using KralInsaat.API.Controllers.Base;
using KralInsaat.Common.DTOs.Branch;
using KralInsaat.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KralInsaat.API.Controllers
{
    public class BranchController : BaseController
    {
        private readonly IBranchService _branchservice;

        public BranchController(IBranchService branch)
        {
            _branchservice = branch;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBranches()
        {
            var data = await _branchservice.GetAllBranchsAsync();

            return Ok(data);
        }

        [HttpGet("{branchId:int}")]
        public async Task<IActionResult> GetBranchById(int branchId)
        {
            var data = await _branchservice.GetBranchByIdAsync(branchId);

            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBranch([FromBody] CreateBranchDTO model)
        {
            await _branchservice.CreateBranchAsync(model);

            return NoContent();
        }

        [HttpPut("{branchId:int}")]
        public async Task<IActionResult> UpdateBranch(int branchId, [FromBody] UpdateBranchDTO model)
        {
            await _branchservice.UpdateBranchAsync(branchId, model);

            return NoContent();
        }

        [HttpDelete("{branchId:int}")]
        public async Task<IActionResult> DeleteBranch(int branchId)
        {
            await _branchservice.DeleteBranchAsync(branchId);

            return NoContent();
        }
    }
}
