using Microsoft.EntityFrameworkCore;

namespace Medallion.Models
{
    public class MedallionContext:DbContext
    {
        public MedallionContext(DbContextOptions<MedallionContext> options):base(options)
        {
        }
        public DbSet<Performance> performances {  get; set; }
        public DbSet<Patron> patrons { get; set; }
        public DbSet<Production> productions { get; set; }
        public DbSet<Report> reports { get; set; }
        public DbSet<Seat> seats { get; set; }
        public DbSet<Reservation> reservations { get; set; }
    }
}
