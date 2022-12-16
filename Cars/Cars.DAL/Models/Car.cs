using System.ComponentModel.DataAnnotations;

namespace Cars.DAL.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }

        public string ModelName { get; set; }

        [Required]
        public CarBrand Brand { get; set; }

        public DateTime? SoldTime { get; set; }

        public double Price { get; set; }
    }
}
