using Swashbuckle.AspNetCore.Filters;

namespace CacheInMemory.DTOs.Examples
{
    public class RegisteredCarReadDTOListExample : IExamplesProvider<List<RegisteredCarReadDTO>>
    {
        public List<RegisteredCarReadDTO> GetExamples()
        {
            return new List<RegisteredCarReadDTO>()
            {
                new RegisteredCarReadDTO()
                {
                    RegisteredCarId = 2,
                    RegistrationCountry = "UY",
                    RegistrationOwner = "Jorge Luis Cuellar Mondeja",
                    RegistrationNumber = "7158 MBK",
                    CarId = 1,
                    CarName = "EQS Berlina",
                    CarDescription = "La elegancia de un coupé unida a la espaciosidad de una berlina.",
                    CarCountry = "ES",
                    CarBranch = "Mercedez Benz",
                    BranchCountry = "DE"
                }
            };
        }
    }
}
