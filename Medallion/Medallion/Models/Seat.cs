namespace Medallion.Models
{
    public class Seat
    {
        public int Id { get; set; }
        public string Section { get; set; }
        public string Number { get; set; }
        public double Price { get; set; }
        public Performance Performance { get; set; }   
    }
}
