using Microsoft.AspNetCore.Mvc;

namespace Medallion.Controllers
{
    public class ProductionController : Controller
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
