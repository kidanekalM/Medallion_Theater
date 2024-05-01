namespace Medallion.Models
{
    public class Production
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public BoxOfficeManager? BoxOfficeManager { get; set; }

    }
}
