using Microsoft.AspNetCore.Mvc;

namespace Medallion.Controllers
{
    public class PerformanceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }
    }
}
