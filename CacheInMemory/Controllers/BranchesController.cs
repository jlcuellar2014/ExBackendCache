using CacheInMemory.DTOs;
using CacheInMemory.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CacheInMemory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchesController(IBranchesService service) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(BadRequestDTO), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(List<BranchReadDTO>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<BranchReadDTO>>> GetAsync()
        {
            try
            {
                return Ok(await service.GetAsync());
            }
            catch (Exception)
            {
                return BadRequest(new BadRequestDTO());
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(BadRequestDTO), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> PostAsync(BranchCreateDTO branch)
        {
            try
            {
                await service.CreateAsync(branch);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest(new BadRequestDTO());
            }
        }

        [HttpPatch("{branchName}")]
        [ProducesResponseType(typeof(BadRequestDTO), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> PatchAsync(string branchName, BranchUpdateDTO branch)
        {
            try
            {
                await service.UpdateAsync(branchName, branch);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new BadRequestDTO{ Message = ex.Message });
            }
            catch (Exception)
            {
                return BadRequest(new BadRequestDTO());
            }
        }

        [HttpDelete("{branchName}")]
        [ProducesResponseType(typeof(BadRequestDTO), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> PatchAsync(string branchName)
        {
            try
            {
                await service.DeleteAsync(branchName);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new BadRequestDTO{ Message = ex.Message });
            }
            catch (Exception)
            {
                return BadRequest(new BadRequestDTO());
            }
        }
    }
}
