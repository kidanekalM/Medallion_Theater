using ChapaNET;
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
            var reserveData = new ReserveDto();
            reserveData.ErrorMessage = "";
            reserveData.seats = _context.seats.Include(s=>s.Performance).ToList();
            return View(reserveData);
        }
        [HttpPost]
        public async Task<IActionResult> Reserve(Reservation reservation)
        {
            ReserveDto reserveDto = new ReserveDto();
            bool Success = true;
            var perfId = reservation.performance.Id;
            var patId = reservation.Patron.PatronId;
            reservation.performance = _context.performances.Where(p => (p.Id).ToString().Equals(perfId.ToString())).FirstOrDefault();
            if(reservation.performance == null)
            {
                reserveDto.ErrorMessage += "Incorrect performance Id! \n";
                Success = false;
            }
            reservation.Patron = _context.patrons.Where(p => p.PatronId.Equals(patId)).FirstOrDefault();
            if(reservation.Patron == null)
            {
                 reserveDto.ErrorMessage += "Incorrect patron Id! \n";
                Success = false;
            }
            var seats = reservation.seats[0].Section.Split(",",StringSplitOptions.RemoveEmptyEntries);
            reservation.seats = new List<Seat>();
            for(var i =0;i< seats.Length;i++)
            {
                var seatName = seats[i].Trim();
                var seat = _context.seats.
                                Where(s => (s.Performance.Id==perfId)).
                                Where(s=>(s.Section.Trim()+" "+ s.Number.Trim()).Equals(seatName)).FirstOrDefault();
                if (seat == null)
                {
                    seat = new Seat()
                    {
                        Section = seatName.Substring(0, seatName.IndexOf(" ")).Trim(),
                        Number = seatName.Substring(seatName.IndexOf(" ")).Trim(),
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
                }
                else
                {
                    reserveDto.ErrorMessage += seatName + " is not currently available. \n";
                    Success = false;
                }
                if (Success)
                {
                    Chapa chapa = new("CHASECK_TEST-rsh3UiMpIBytuEGhtyBPKtRU6ziR7Anj");

                    var ID = Chapa.GetUniqueRef();

                    var Request = new ChapaRequest(
                        amount: 0,
                        email: "golden1flying1eagle@gmail.com",
                        firstName: reservation.Patron.FirstName,
                        lastName: reservation.Patron.LastName,
                        tx_ref: ID,
                        callback_url: "http://localhost:7269/Reservation",
                        customDescription: "Payment for seat reservation ",
                        customTitle:"Seat Reservation"
                    );
                    foreach( var seatPr in reservation.seats)
                    {
                        Request.Amount += seatPr.Price;
                    }
                    var Result = await chapa.RequestAsync(Request);
                    Console.WriteLine(Result);
                    _context.reservations.Add(reservation);
                    _context.SaveChanges();
                    return Redirect(Result.CheckoutUrl);
                }

            }
            return View((object)reserveDto);
        }
    }
}
