using CacheInMemory.DTOs;
using CacheInMemory.Services;
using Microsoft.AspNetCore.Mvc;

namespace CacheInMemory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController(ICountriesService service) : ControllerBase
    {
        [HttpGet("is-alive")]
        public ActionResult IsAlive() => Ok();


        [HttpGet]
        public async Task<ActionResult<List<CountryReadDTO>>> GetAsync()
        {
            try
            {
                return Ok(await service.GetAsync());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
