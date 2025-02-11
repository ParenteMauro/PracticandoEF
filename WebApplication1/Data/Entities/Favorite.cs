using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Data.Entities
{
    public class Favorite
    {
        [Key]
        public int Id { get; set; }


        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }

        [Required]
        [ForeignKey("Product")]
        public int product_Id { get; set; }
    }
}
