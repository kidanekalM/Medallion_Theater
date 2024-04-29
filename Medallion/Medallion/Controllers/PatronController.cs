using Medallion.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;

namespace Medallion.Controllers
{
    public class PatronController : Controller
    {
        private readonly MedallionContext _context;
        public PatronController(MedallionContext medallionContext) 
        {
            _context = medallionContext;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View(_context.patrons.ToList<Patron>());
        }
        public IActionResult GetAll()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(Patron patron)
        {
            _context.patrons.Add(patron);
            _context.SaveChanges();
            return View();
        }
        public IActionResult Details(string id)
        {
            Patron patron = _context.patrons.Where(p=>p.PatronId.Equals(id)).FirstOrDefault();
            return View(patron);
        }
        [HttpPost]
        public IActionResult Edit(string id, Patron updatedPatron)
        {
            _context.patrons.Update(updatedPatron);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(string id)
        {
            Patron patron = _context.patrons.Where(p => p.PatronId.Equals(id)).FirstOrDefault();
            return View(patron);
        }


    }
}
