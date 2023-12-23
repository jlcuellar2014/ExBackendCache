using Swashbuckle.AspNetCore.Filters;

namespace CacheInMemory.DTOs.Examples
{
    public class CountryReadDTOListExample : IExamplesProvider<List<CountryReadDTO>>
    {
        public List<CountryReadDTO> GetExamples()
        {
            return new List<CountryReadDTO>
            {
                new CountryReadDTO
                {
                    CountryCode = "ES",
                    CountryName = "España",
                }
            };
        }
    }
}
