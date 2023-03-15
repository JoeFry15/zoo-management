namespace zoo_mgmt.Models.Request
{
    public class SearchRequest
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string OrderBy { get; set; }
    }



    public class AnimalSearchRequest : SearchRequest
    {
        public string? Name { get; set; }
        public string? Species { get; set; }
        public string? Classification { get; set; }
        public int? Age { get; set; }
        public DateTime? AcquiredDate { get; set; }
        public int? Enclosure_id { get; set; }
    }

    public class ZooKeeperSearchRequest : SearchRequest
    {
        public string? Name { get; set; }
    }
}
