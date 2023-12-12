using Swashbuckle.AspNetCore.Filters;

namespace CacheInMemory.DTOs.Examples
{
    public class RegisteredCarReadDTOListExample : IExamplesProvider<List<RegisteredCarReadDTO>>
    {
        public List<RegisteredCarReadDTO> GetExamples()
        {
            return new List<RegisteredCarReadDTO>
            {
                new RegisteredCarReadDTO
                {
                    CarId = 1,
                    CarName = "Sedan Mercedes Benz",
                    CarBranch = "Mercedes Benz",
                    CarCountry = "DE",
                    CarDescription = "Sedan Mercedes Benz made in Germany",
                    BranchCountry = "DE",
                    RegisteredCarId = 1,
                    RegistrationCountry = "ES",
                    RegistrationNumber = "7158 MBK",
                    RegistrationOwner = "Jorge Luis Cuellar Mondeja"
                }
            };
        }
    }
}
