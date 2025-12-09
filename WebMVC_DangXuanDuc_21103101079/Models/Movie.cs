using System.ComponentModel.DataAnnotations;

namespace WebMVC_DangXuanDuc_21103101079.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Director { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        [Range(1900, 2100)]
        public int ReleaseYear { get; set; }
        [Required]
        [Range(1, 10)]
        public int Rating { get; set; }
    }
}
