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
                CountryCode = "ES",
                Owner = "Jorge Luis Cuellar Mondeja",
                RegistrationNumber = "7158 MBK"
            };
        }
    }
}
