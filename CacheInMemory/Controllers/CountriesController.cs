using CacheInMemory.Cache;
using CacheInMemory.Services;
using Microsoft.AspNetCore.Mvc;

namespace CacheInMemory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController(ICountriesService service) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(service.GetCountriesAsync());
        }
    }
}
