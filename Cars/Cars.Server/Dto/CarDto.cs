using Cars.DAL.Models;

namespace Cars.Server.Dto
{
    public class CarDto
    {
        public int Id { get; set; }

        public string ModelName { get; set; }

        public string Brand { get; set; }

        public DateTime? SoldTime { get; set; }

        public double Price { get; set; }
    }
}
