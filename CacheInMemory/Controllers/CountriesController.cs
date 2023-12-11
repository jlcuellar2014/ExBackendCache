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
        public ActionResult<List<CountryReadDTO>> Get()
        {
            try
            {
                return Ok(service.GetCountries());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
