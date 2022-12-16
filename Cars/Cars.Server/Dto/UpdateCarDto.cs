using System.ComponentModel.DataAnnotations;

namespace Cars.Server.Dto
{
    public class UpdateCarDto
    {
        [Required]
        public string ModelName { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public string BrandName { get; set; }
    }
}
