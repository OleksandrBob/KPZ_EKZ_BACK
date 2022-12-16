namespace Cars.Server.Dto
{
    public class SellerDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public double Comission { get; set; } = 0;
    }
}
