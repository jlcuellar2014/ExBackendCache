using CacheInMemory.DTOs;
using CacheInMemory.Services;
using Microsoft.AspNetCore.Mvc;

namespace CacheInMemory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController(ICountriesService service) : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<CountryDTO>> Get()
        {
            try
            {
                return Ok(service.GetCountriesAsync());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
