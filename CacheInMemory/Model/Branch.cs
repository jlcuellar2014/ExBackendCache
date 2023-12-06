using System.ComponentModel.DataAnnotations.Schema;

namespace CacheInMemory.Model
{
    public class Branch
    {
        public int BranchId { get; set; }
        public required string CountryCode { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }

        [NotMapped]
        public Country? Nacionality { get; set; }

        [NotMapped]
        public List<Car>? Cars { get; set; }
    }
}
