using Swashbuckle.AspNetCore.Filters;

namespace CacheInMemory.DTOs.Examples
{
    public class CarCreateDTOExample : IExamplesProvider<CarCreateDTO>
    {
        public CarCreateDTO GetExamples()
        {
            return new CarCreateDTO
            {
                BranchId = 1,
                CountryCode = "DE",
                Name = "Berlina 508",
                Description = "Berlina Mercedes Benz"
            };
        }
    }
}
