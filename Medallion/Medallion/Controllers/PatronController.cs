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
            return View();
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
        [HttpPut]
        public IActionResult Edit()
        {
            return View();
        }
        [HttpDelete]
        public IActionResult Delete()
        {
            return View();
        }


    }
}
