using Medallion.Models;
using Microsoft.AspNetCore.Mvc;

namespace Medallion.Controllers
{
    public class PatronController : Controller
    {
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
            return View();
        }


    }
}
