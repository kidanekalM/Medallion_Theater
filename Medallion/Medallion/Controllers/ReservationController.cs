using Microsoft.AspNetCore.Mvc;

namespace Medallion.Controllers
{
    public class ReservationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Reserve()
        {
            return View();
        }
    }
}
