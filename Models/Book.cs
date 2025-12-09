using MessagePack;
using System.ComponentModel.DataAnnotations;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace WebAPI_DangXuanDuc_21103101079.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(100)]
        public string Author { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }
        [Required]
        [Range(1900, 2100)]
        public int PublicationYear { get; set; }
    }
}
