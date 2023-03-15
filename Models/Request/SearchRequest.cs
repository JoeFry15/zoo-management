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
        public string? Enclosure { get; set; }
    }

    public class ZooKeeperSearchRequest : SearchRequest
    {
        public string? Name { get; set; }
    }
}

// public class UserSearchRequest : SearchRequest
// {
//     private string _search;

//     public string Search
//     {
//         get => _search?.ToLower();
//         set => _search = value;
//     }

//     public override string Filters => Search == null ? "" : $"&search={Search}";
// }

//     public class FeedSearchRequest : PostSearchRequest
//     {
//         public int? LikedBy { get; set; }
//         public int? DislikedBy { get; set; }
//         public override string Filters
//         {
//             get
//             {
//                 var filters = "";

//                 if (PostedBy != null)
//                 {
//                     filters += $"&postedBy={PostedBy}";
//                 }

//                 if (LikedBy != null)
//                 {
//                     filters += $"&likedBy={LikedBy}";
//                 }

//                 if (DislikedBy != null)
//                 {
//                     filters += $"&dislikedBy={DislikedBy}";
//                 }

//                 return filters;
//             }
//         }
//     }
// }