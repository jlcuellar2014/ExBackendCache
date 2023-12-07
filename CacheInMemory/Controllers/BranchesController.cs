﻿using CacheInMemory.DTOs;
using CacheInMemory.Services;
using Microsoft.AspNetCore.Mvc;

namespace CacheInMemory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchesController(IBranchesService service) : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<BranchReadDTO>> Get()
        {
            try
            {
                return Ok(service.GetBranches());
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
                await service.CreateBranchAsync(branch);
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
                await service.UpdateBranchAsync(branchName, branch);
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
                await service.DeleteBranchAsync(branchName);
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
