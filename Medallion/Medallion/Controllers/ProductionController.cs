using Medallion.Models;
using Microsoft.AspNetCore.Mvc;

namespace Medallion.Controllers
{
    public class ProductionController : Controller
    {
        private readonly MedallionContext _context;
        public ProductionController(MedallionContext medallionContext)
        {
            _context = medallionContext;
        }
        public IActionResult Index()
        {
            var prods = _context.productions.ToList<Production>();
            return View(prods);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Production production)
        {
            _context.productions.Add(production);
            _context.SaveChanges();
            return View();
        }
        [HttpPost]
        public IActionResult Update(int id, Production updatedProduction)
        {
            Production production = _context.productions.Where(p => p.Id == id).FirstOrDefault();
            if (production != null)
            {
                production = updatedProduction;
                _context.productions.Update(production);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Production production = _context.productions.Where(p => p.Id == id).FirstOrDefault();
            if (production != null)
            {
                _context.productions.Remove(production);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult Details(string Id)
        {
            var prod = _context.productions.Where(p => (p.Id).ToString().Equals(Id)).FirstOrDefault();
            //Patron patron = _context.patrons.Where(p => p.PatronId.Equals(id)).FirstOrDefault();
            Console.WriteLine(Id,prod);
            return View(prod);
        }
    }
}
