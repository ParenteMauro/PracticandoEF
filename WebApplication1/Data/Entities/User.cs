using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; } 

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string? SurName { get; set; }


        [EmailAddress]
        [Required]
        
        public string EmailAddress { get; set; }


        public string? Phone { get; set; }
    }
}
