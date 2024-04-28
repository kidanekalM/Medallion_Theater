namespace Medallion.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public string TicketId { get; set; }
        public Patron Patron { get; set; }
        public Performance performance { get; set; }
        public List<Seat> seats { get; set; }
    }
}
