using Medallion.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.AccessControl;

namespace Medallion.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MedallionContext _context;
        public HomeController(ILogger<HomeController> logger, MedallionContext medallionContext)
        {
            _logger = logger;
            _context = medallionContext;
        }
        public IActionResult Index()
        {
            List<Report> reports = new List<Report>{
            new Report
            {
                Id = 1,
                Data = "patrons: " + _context.patrons.Count(),
                Type = "Patron Data"
            },
            new Report
            {
                Id = 2,
                Data = "Productions: " + _context.productions.Count(),
                Type = "Production Data"
            },
            new Report
            {
                Id = 3,
                Data = "Performances: " + _context.performances.Count(),
                Type = "Performance Data"
            },
            new Report
            {
                Id = 4,
                Data = "Reservations: "+ _context.reservations.Count(),
                Type="Reservation Data"
            }
            };
            return View("Dashboard",reports);
        }
        public IActionResult Dashboard()
        {
            List<Report> reports = new List<Report>{
            new Report
            {
                Id = 1,
                Data = "patrons: " + _context.patrons.Count(),
                Type = "Patron Data"
            },
            new Report
            {
                Id = 2,
                Data = "Productions: " + _context.productions.Count(),
                Type = "Production Data"
            },
            new Report
            {
                Id = 3,
                Data = "Performances: " + _context.performances.Count(),
                Type = "Performance Data"
            },
            new Report
            {
                Id = 4,
                Data = "Reservations: "+ _context.reservations.Count(),
                Type="Reservation Data"
            }
            };
            return View(reports);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}