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
            return View();
        }
        //Update Details
        [HttpPost]
        public IActionResult Details(Performance updatedPerformance)
        {

            Performance performance = _context.performances.Where(p => p.Id == updatedPerformance.Id).FirstOrDefault();
            if (performance != null)
            {
                performance.production = _context.productions.Where(p => (p.Id).ToString().Equals(updatedPerformance.production.Id.ToString())).FirstOrDefault();
                performance.dateTime = updatedPerformance.dateTime;
                performance.Type = updatedPerformance.Type;
                _context.performances.Update(performance);
                _context.SaveChanges();
            }
            return View("Update");
        }

        public IActionResult Delete(int id)
        {
            Performance performance = _context.performances.Where(p => p.Id == id).FirstOrDefault();
            if (performance != null)
            {
                _context.performances.Remove(performance);
                _context.SaveChanges();
            }
            return View("Delete");
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
