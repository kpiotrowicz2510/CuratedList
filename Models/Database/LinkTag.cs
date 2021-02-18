using System.ComponentModel.DataAnnotations;

namespace CuratedList.Models
{
    public class LinkTag
    {
        [Key]
        public int Id { get; set; }
        public LinkEntry Entry { get; set; }
        public string Name { get; set; }
    }
}