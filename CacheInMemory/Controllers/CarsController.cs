using CacheInMemory.DTOs;
using CacheInMemory.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CacheInMemory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController(ICarsService service) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(BadRequestDTO), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(List<CarReadDTO>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<CarReadDTO>>> GetAsync()
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

        [HttpGet("search")]
        [ProducesResponseType(typeof(BadRequestDTO), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(List<CarReadDTO>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<CarReadDTO>>> GetByParamsAsync([FromQuery] CarSearchingDTO carSearching)
        {
            try
            {
                return Ok(await service.GetByParamsAsync(carSearching));
            }
            catch (Exception)
            {
                return BadRequest(new BadRequestDTO());
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(BadRequestDTO), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> PostAsync(CarCreateDTO car)
        {
            try
            {
                await service.CreateAsync(car);
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

        [HttpPatch("{carId}")]
        [ProducesResponseType(typeof(BadRequestDTO), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> PatchAsync(int carId, CarUpdateDTO car)
        {
            try
            {
                await service.UpdateAsync(carId, car);
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
