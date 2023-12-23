using Swashbuckle.AspNetCore.Filters;

namespace CacheInMemory.DTOs.Examples
{
    public class CarSearchingDTOExample : IExamplesProvider<CarSearchingDTO>
    {
        public CarSearchingDTO GetExamples()
        {
            return new CarSearchingDTO
            {
                
                BranchId = 1,
                CountryCode = "ES",
                CarName = "berlina",
                CarDescription = "berlina"
            };
        }
    }
}
