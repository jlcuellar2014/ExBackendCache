namespace CacheInMemory.Records
{
    public record CarSearchingRecord
    {
        public int? CarId { get; set; }
        public string? CarName { get; set; }
        public string? CarDescription { get; set; }
        public int? BranchId { get; set; }
        public string? BranchName { get; set; }
        public string? CountryCode { get; set; }
        public string? CountryName { get; set; }
    }
}
