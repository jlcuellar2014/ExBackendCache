using System.ComponentModel.DataAnnotations.Schema;

namespace CacheInMemory.Model
{
    public class Car
    {
        public int CarId { get; set; }
        public int BranchId { get; set; }
        public required string CountryCode { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        [NotMapped]
        public Country? Nacionality { get; set; }
        [NotMapped]
        public Branch? Branch { get; set; }
    }
}
