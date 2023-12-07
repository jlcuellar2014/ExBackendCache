namespace CacheInMemory.DTOs
{
    public class CarReadDTO
    {
        public int CarId { get; set; }
        public int BranchId { get; set; }
        public required string CountryCode { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}
