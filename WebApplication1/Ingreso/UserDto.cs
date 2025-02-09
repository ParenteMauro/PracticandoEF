using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Ingreso
{
    public class UserDto
    {
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
