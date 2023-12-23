using Swashbuckle.AspNetCore.Filters;

namespace CacheInMemory.DTOs.Examples
{
    public class RegisteredCarUpdateDTOExample : IExamplesProvider<RegisteredCarUpdateDTO>
    {
        public RegisteredCarUpdateDTO GetExamples()
        {
            return new RegisteredCarUpdateDTO
            {
                CarId = 1,
                CountryCode = "DE",
                RegistrationNumber = "7158 MBK",
                Owner = "Jorge Luis Cuellar Mondeja"
            };
        }
    }
}
