using Swashbuckle.AspNetCore.Filters;

namespace CacheInMemory.DTOs.Examples
{
    public class CarReadDTOListExample : IExamplesProvider<List<CarReadDTO>>
    {
        public List<CarReadDTO> GetExamples()
        {
            return new List<CarReadDTO>
            {
                new CarReadDTO
                {
                    CarId = 1,
                    BranchId = 1,
                    CountryCode = "ES",
                    Name = "EQS Berlina",
                    Description = "La elegancia de un coupé unida a la espaciosidad de una berlina."
                }
            };
        }
    }
}
