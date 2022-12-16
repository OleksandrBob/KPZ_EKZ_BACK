using System.ComponentModel.DataAnnotations;

namespace Cars.DAL.Models
{
    public class Operation
    {
        [Key]
        public int Id { get; set; }

        public int CarId { get; set; }

        public Car Car { get; set; }

        public int SellerId { get; set; }

        public Seller Seller { get; set; }

        [Required]
        public DateTime TransactionTime { get; set; }

        public string Description { get; set; }
    }
}
