using Microsoft.AspNetCore.Mvc;

namespace Medallion.Controllers
{
    public class PerformanceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
