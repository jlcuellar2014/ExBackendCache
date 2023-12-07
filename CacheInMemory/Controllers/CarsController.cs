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
        public ActionResult<List<CarReadDTO>> Get()
        {
            try
            {
                return Ok(service.GetCars());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("search")]
        public ActionResult<List<CarReadDTO>> GetByParams([FromQuery] CarSearchingDTO carSearching)
        {
            try
            {
                return Ok(service.GetCarsByParams(carSearching));
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
