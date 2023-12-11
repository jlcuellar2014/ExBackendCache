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
                return Ok(await service.GetCarsAsync());
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
                return Ok(await service.GetCarsByParamsAsync(carSearching));
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
                await service.CreateCarAsync(car);
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
                await service.UpdateCarAsync(carId, car);
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
