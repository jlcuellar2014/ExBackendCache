using Swashbuckle.AspNetCore.Filters;

namespace CacheInMemory.DTOs.Examples
{
    public class BranchReadDTOListExample : IExamplesProvider<List<BranchReadDTO>>
    {
        public List<BranchReadDTO> GetExamples()
        {
            return new List<BranchReadDTO> {
                new BranchReadDTO
                {
                    BranchId = 1,
                    Name = "Mercedes Benz",
                    Description = "German Cars",
                    CountryCode = "DE"

                },
                new BranchReadDTO
                {
                    BranchId = 2,
                    Name = "Toyota",
                    CountryCode = "JP",
                    Description = "Japanise branch"
                }
            };
        }
    }
}
