using System.ComponentModel.DataAnnotations;

namespace Cars.DAL.Models
{
    public class Seller
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public double Comission { get; set; } = 0;
    }
}
