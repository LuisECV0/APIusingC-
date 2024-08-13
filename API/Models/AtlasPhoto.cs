using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class AtlasPhoto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Titler { get; set; }
        public string Photographer { get; set; }
        public string Description { get; set; }
        [Required]
        public string ImageUrl { get; set; }
       // public string Title { get; set; }


    }
}
