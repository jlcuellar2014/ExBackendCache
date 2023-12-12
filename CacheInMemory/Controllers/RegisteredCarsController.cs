using CacheInMemory.DTOs;
using CacheInMemory.Services;
using Microsoft.AspNetCore.Mvc;

namespace CacheInMemory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisteredCarsController(IRegisteredCarsService service) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<RegisteredCarReadDTO>>> GetAsync()
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

        [HttpPost]
        public async Task<ActionResult> PostAsync(RegisteredCarCreateDTO registeredCar)
        {
            try
            {
                await service.CreateAsync(registeredCar);
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

        [HttpPatch("{idRegister}")]
        public async Task<ActionResult> PatchAsync(int idRegister, RegisteredCarUpdateDTO registeredCar)
        {
            try
            {
                await service.UpdateAsync(idRegister, registeredCar);
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

        [HttpDelete("{idRegister}")]
        public async Task<ActionResult> DeleteAsync(int idRegister)
        {
            try
            {
                await service.DeleteAsync(idRegister);
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
