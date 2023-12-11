using CacheInMemory.DTOs;
using CacheInMemory.Services;
using Microsoft.AspNetCore.Mvc;

namespace CacheInMemory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchesController(IBranchesService service) : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<BranchReadDTO>> GetAll()
        {
            try
            {
                return Ok(service.GetAll());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(BranchCreateDTO branch)
        {
            try
            {
                await service.CreateAsync(branch);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPatch("{branchName}")]
        public async Task<ActionResult> PatchAsync(string branchName, BranchUpdateDTO branch)
        {
            try
            {
                await service.UpdateAsync(branchName, branch);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{branchName}")]
        public async Task<ActionResult> PatchAsync(string branchName)
        {
            try
            {
                await service.DeleteAsync(branchName);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
