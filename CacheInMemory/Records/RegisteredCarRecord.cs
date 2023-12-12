namespace CacheInMemory.Records
{
    public class RegisteredCarRecord
    {
        public int RegisteredCarId { get; set; }
        public string? RegistrationCountry { get; set; }
        public string? RegistrationOwner { get; set; }
        public string? RegistrationNumber { get; set; }

        public int CarId { get; set; }
        public string? CarName { get; set; }
        public string? CarDescription { get; set; }
        public string? CarCountry { get; set; }

        public string? CarBranch { get; set; }
        public string? BranchCountry { get; set; }
    }
}
