using CacheInMemory.DTOs;
using CacheInMemory.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CacheInMemory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController(ICountriesService service) : ControllerBase
    {
        [HttpGet("is-alive")]
        public ActionResult IsAlive() => Ok();


        [HttpGet]
        [ProducesResponseType(typeof(BadRequestDTO), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(List<CountryReadDTO>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<CountryReadDTO>>> GetAsync()
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
    }
}
