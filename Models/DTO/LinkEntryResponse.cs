using System.Collections.Generic;

namespace CuratedList.Models.DTO
{
    public class LinkEntryResponse
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        
        public string Name { get; set; }
        public string TargetUrl { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public List<LinkTagResponse> Tags { get; set; }
        public string HighestTag { get; set; }
    }
}