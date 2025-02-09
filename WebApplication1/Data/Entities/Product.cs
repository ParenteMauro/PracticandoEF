using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [StringLength(2000)]
        public string? Description { get; set; }

        public decimal? Price { get; set; }
    }
}
