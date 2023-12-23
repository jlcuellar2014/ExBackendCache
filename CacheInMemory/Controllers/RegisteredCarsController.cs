using CacheInMemory.DTOs;
using CacheInMemory.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CacheInMemory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisteredCarsController(IRegisteredCarsService service) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(BadRequestDTO), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(List<RegisteredCarReadDTO>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<RegisteredCarReadDTO>>> GetAsync()
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

        [HttpPost]
        [ProducesResponseType(typeof(BadRequestDTO), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> PostAsync(RegisteredCarCreateDTO registeredCar)
        {
            try
            {
                await service.CreateAsync(registeredCar);
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

        [HttpPatch("{idRegister}")]
        [ProducesResponseType(typeof(BadRequestDTO), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> PatchAsync(int idRegister, RegisteredCarUpdateDTO registeredCar)
        {
            try
            {
                await service.UpdateAsync(idRegister, registeredCar);
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

        [HttpDelete("{idRegister}")]
        [ProducesResponseType(typeof(BadRequestDTO), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> DeleteAsync(int idRegister)
        {
            try
            {
                await service.DeleteAsync(idRegister);
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
