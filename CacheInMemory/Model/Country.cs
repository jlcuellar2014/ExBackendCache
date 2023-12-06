using System.ComponentModel.DataAnnotations;

namespace CacheInMemory.Model
{
    public class Country
    {
        [StringLength(2, MinimumLength = 2)]
        public required string CountryCode { get; set; }
        [StringLength(200)]
        public required string CountryName { get; set; }
    }
}
