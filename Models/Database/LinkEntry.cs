using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CuratedList.Models
{
    public class LinkEntry
    {
        [Key]
        public int Id { get; set; }
        public ApplicationUser User { get; set; }
        
        public string Name { get; set; }
        public string TargetUrl { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public List<LinkTag> Tags { get; set; }
    }
}