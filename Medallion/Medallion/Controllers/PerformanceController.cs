using Medallion.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Medallion.Controllers
{
    public class PerformanceController : Controller
    {
        private readonly MedallionContext _context;
        public PerformanceController(MedallionContext medallionContext)
        {
            _context = medallionContext;
        }
        public IActionResult Index()
        {
            var perf = _context.performances.Include(p=>p.production).ToList<Performance>();
            return View(perf);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Performance performance)
        {
            Console.WriteLine(performance);
            performance.production = _context.productions.Where(p => (p.Id).ToString().Equals(performance.production.Id.ToString())).FirstOrDefault();
            _context.performances.Add(performance);
            _context.SaveChanges();
            //for(var j = "A".ToCharArray()[0]; j <= "F".ToCharArray()[0]; j++)
            //{
            //    for(var i = 0; i < 31; i++)
            //    {
            //        Seat seat = new Seat()
            //        {
            //            Section = j.ToString(),
            //            Number=(i+1).ToString(),
            //            Price = 65,
            //            Performance = performance,
            //            Status = true
            //        };
            //    }
            //}
            //for (var j = "G".ToCharArray()[0]; j <= "N".ToCharArray()[0]; j++)
            //{
            //    for (var i = 0; i < 31; i++)
            //    {
            //        Seat seat = new Seat()
            //        {
            //            Section = j.ToString(),
            //            Number = (i + 1).ToString(),
            //            Price = 55,
            //            Performance = performance,
            //            Status = true
            //        };
            //    }
            //}
            //for (var j = "A".ToCharArray()[0]; j <= "F".ToCharArray()[0]; j++)
            //{
            //    for (var i = 0; i < 31; i++)
            //    {
            //        Seat seat = new Seat()
            //        {
            //            Section = j.ToString()+ j.ToString(),
            //            Number = (i + 1).ToString(),
            //            Price = 40,
            //            Performance = performance,
            //            Status = true
            //        };
            //    }
            //}
            //for (var i = 0; i < 15; i++)
            //{
            //    Seat seat = new Seat()
            //    {
            //        Section ="X",
            //        Number = (i + 1).ToString(),
            //        Price = 85,
            //        Performance = performance,
            //        Status = true
            //    };
            //}
            return View();
        }
        public IActionResult Details(string Id)
        {
            var perf = _context.performances.Include(p=>p.production).Where(p => (p.Id).ToString().Equals(Id)).FirstOrDefault();
            //Patron patron = _context.patrons.Where(p => p.PatronId.Equals(id)).FirstOrDefault();
            Console.WriteLine(Id, perf);
            return View(perf);
        }
    }
}
