using System.ComponentModel.DataAnnotations;

namespace Cars.DAL.Models
{
    public class CarBrand
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public List<Car> CarsOfBrand { get; set; }
    }
}
