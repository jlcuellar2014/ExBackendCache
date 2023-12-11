using CacheInMemory.DTOs;
using CacheInMemory.Services;
using Microsoft.AspNetCore.Mvc;

namespace CacheInMemory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController(ICarsService service) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<CarReadDTO>>> GetAsync()
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

        [HttpGet("search")]
        public async Task<ActionResult<List<CarReadDTO>>> GetByParamsAsync([FromQuery] CarSearchingDTO carSearching)
        {
            try
            {
                return Ok(await service.GetByParamsAsync(carSearching));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<ActionResult<List<CarReadDTO>>> PostAsync(CarCreateDTO car)
        {
            try
            {
                await service.CreateAsync(car);
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

        [HttpPatch("{carId}")]
        public async Task<ActionResult<List<CarReadDTO>>> PatchAsync(int carId, CarUpdateDTO car)
        {
            try
            {
                await service.UpdateAsync(carId, car);
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
