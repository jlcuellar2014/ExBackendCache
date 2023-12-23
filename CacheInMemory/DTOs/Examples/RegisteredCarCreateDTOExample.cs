using Swashbuckle.AspNetCore.Filters;

namespace CacheInMemory.DTOs.Examples
{
    public class RegisteredCarCreateDTOExample : IExamplesProvider<RegisteredCarCreateDTO>
    {
        public RegisteredCarCreateDTO GetExamples()
        {
            return new RegisteredCarCreateDTO
            {
                CarId = 1,
                CountryCode = "DE",
                RegistrationNumber = "7158 MBK",
                Owner = "Jorge Luis Cuellar Mondeja"
            };
        }
    }
}
