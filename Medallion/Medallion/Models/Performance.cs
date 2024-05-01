namespace Medallion.Models
{
    public class Performance
    {
        public int Id { get; set; }
        public Production production{ get; set; }
        public DateTime dateTime { get; set; }
        public string Type { get; set; }
        public BoxOfficeManager? boxOfficeManager { get; set; }

    }
}
