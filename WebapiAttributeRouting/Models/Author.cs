using System.ComponentModel.DataAnnotations;

namespace WebapiAttributeRouting.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}