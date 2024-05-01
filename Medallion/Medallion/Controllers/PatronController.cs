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
            var patron=_context.patrons.Where(p=>p.PatronId.Equals(id)).FirstOrDefault();
            return View(patron);
        }
        //Does the updating
        [HttpPost]
        public IActionResult Details( Patron updatedPatron)
        {
            var oldPat = _context.patrons.FirstOrDefault(p => p.PatronId == updatedPatron.PatronId);

            if (oldPat != null)
            {
                oldPat.FirstName = updatedPatron.FirstName;
                oldPat.LastName = updatedPatron.LastName;
                oldPat.Address = updatedPatron.Address;
                oldPat.City = updatedPatron.City;
                oldPat.Region = updatedPatron.Region;
                oldPat.ZipCode = updatedPatron.ZipCode;
                oldPat.CellPhone = updatedPatron.CellPhone;
                oldPat.Email = updatedPatron.Email;

                _context.patrons.Update(oldPat);
                _context.SaveChanges();
            }

            return View("Update");
        }
        public IActionResult Delete(string id)
        {
            Patron patron = _context.patrons.Where(p => p.PatronId.Equals(id)).FirstOrDefault();
            _context.patrons.Remove(patron);
            _context.SaveChanges();
            Redirect("https://localhost:7269/Patron");
            return View();

        }


    }
}
