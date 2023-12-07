namespace CacheInMemory.DTOs
{
    public class RegisteredCarCreateDTO
    {
        public int CarId { get; set; }
        public required string CountryCode { get; set; }
        public required string Owner { get; set; }
        public required string RegistrationNumber { get; set; }
    }
}
