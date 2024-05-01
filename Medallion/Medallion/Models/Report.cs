namespace Medallion.Models
{
    public class Report
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Data { get; set; }
        public BoxOfficeManager? BoxOfficeManager { get; set; }  
    }
}
