using System.ComponentModel.DataAnnotations.Schema;

namespace CacheInMemory.Model
{
    public class RegisteredCar
    {
        public int RegisteredCarId { get; set; }
        public int CarId { get; set; }
        public required string CountryCode { get; set; }
        public required string Owner { get; set; }
        public required string RegistrationNumber { get; set; }
        [NotMapped]
        public Country? County { get; set; }
    }
}
