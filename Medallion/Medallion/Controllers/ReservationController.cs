using Medallion.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Medallion.Controllers
{
    public class ReservationController : Controller
    {
        private readonly MedallionContext _context;
        public ReservationController(MedallionContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var perf = _context.reservations.Include(p => p.Patron).Include(p=>p.performance).ToList<Reservation>();
            return View(perf);
        }
        [HttpGet]
        public IActionResult Reserve()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Reserve(Reservation reservation)
        {
            reservation.performance = _context.performances.Where(p => (p.Id).ToString().Equals(reservation.performance.Id.ToString())).FirstOrDefault();
            reservation.Patron = _context.patrons.Where(p => p.PatronId.Equals(reservation.Patron.PatronId)).FirstOrDefault();
            var seat = _context.seats.Include(s => s.Performance).
                            Where(s => s.Performance.Id.Equals(reservation.performance.Id)).
                            Where(s=>(s.Section+" "+ s.Number).Equals(reservation.seats[0].Id)).FirstOrDefault();
            if(seat == null)
            {
                seat = new Seat()
                {
                    Section = reservation.seats[0].Section.Substring(0, reservation.seats[0].Section.IndexOf(" ")),
                    Number = reservation.seats[0].Section.Substring(reservation.seats[0].Section.IndexOf(" ")),
                    Performance = reservation.performance,
                    Price = reservation.seats[0].Price,
                };
                reservation.seats = new List<Seat>()
                {
                    seat
                };
                reservation.TicketId = reservation.seats[0].Section + Guid.NewGuid().ToString();
                Console.WriteLine(reservation);
                _context.reservations.Add(reservation);
            _   context.SaveChanges();
            return View();
            }
            else
            {
                return View("Error! Seat Already Taken.");
            }
            // DOes the seat exist
            // error 
            // not error
            
        }
    }
}
