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
            var perf = _context.reservations.Include(p => p.Patron).Include(p=>p.performance).Include(p=>p.performance.production).Include(p=>p.seats).ToList<Reservation>();
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
            string ErrorMessage="";
            reservation.performance = _context.performances.Where(p => (p.Id).ToString().Equals(reservation.performance.Id.ToString())).FirstOrDefault();
            reservation.Patron = _context.patrons.Where(p => p.PatronId.Equals(reservation.Patron.PatronId)).FirstOrDefault();
            var seats = reservation.seats[0].Section.Split(",",StringSplitOptions.RemoveEmptyEntries);
            reservation.seats = new List<Seat>();
            foreach(string seatName in seats)
            {
                var seater = _context.seats.ToList();
                seater.ForEach((s) =>
                {
                    string v = s.Section + " " + s.Number;
                    Console.WriteLine(v);

                });
                Console.WriteLine(seater);

                var seat = _context.seats.
                                Where(s => (s.Performance.Id==reservation.performance.Id)).
                                Where(s=>(s.Section.Trim()+" "+ s.Number.Trim()).Equals(seatName)).FirstOrDefault();
                if (seat == null)
                {
                    seat = new Seat()
                    {
                        Section = reservation.seats[0].Section.Substring(0, reservation.seats[0].Section.IndexOf(" ")),
                        Number = reservation.seats[0].Section.Substring(reservation.seats[0].Section.IndexOf(" ")),
                        Performance = reservation.performance,
                    };

                    string section = seat.Section.ToUpper();

                    if (section.CompareTo("A") >= 0 && section.CompareTo("F") <= 0)
                    {
                        seat.Price = 65;
                    }
                    else if (section.CompareTo("G") >= 0 && section.CompareTo("N") <= 0)
                    {
                        seat.Price = 55;
                    }
                    else if (section.CompareTo("AA") >= 0 && section.CompareTo("EE") <= 0)
                    {
                        seat.Price = 40;
                    }
                    else if (section == "X")
                    {
                        seat.Price = 85;
                    }


                    reservation.seats.Add(seat);
                    reservation.TicketId = reservation.seats[0].Section + Guid.NewGuid().ToString();
                    Console.WriteLine(reservation);
                    _context.reservations.Add(reservation);
                    _context.SaveChanges();
                    //return View((object)"");
                }
                else
                {
                    ErrorMessage += seatName + " was already taken. \n";
                }

            }
            Console.WriteLine(ErrorMessage);
            return View((object)ErrorMessage);
        }
    }
}
