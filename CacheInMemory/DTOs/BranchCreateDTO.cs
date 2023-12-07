namespace CacheInMemory.DTOs
{
    public class BranchCreateDTO
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required string CountryCode { get; set; }
    }
}
