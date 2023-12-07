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
        public ActionResult<List<RegisteredCarReadDTO>> Get()
        {
            try
            {
                return Ok(service.GetRegisteredCars());
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
                await service.CreateRegisteredCarAsync(registeredCar);
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
                await service.UpdateRegisteredCarAsync(idRegister, registeredCar);
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
                await service.DeleteRegisteredCarAsync(idRegister);
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
