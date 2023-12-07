using System.ComponentModel.DataAnnotations;

namespace CacheInMemory.DTOs
{
    public class CountryReadDTO
    {
        public string? CountryCode { get; set; }
        public string? CountryName { get; set; }
    }
}
