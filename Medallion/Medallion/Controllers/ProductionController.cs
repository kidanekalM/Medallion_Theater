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
        //Does the updating 
        [HttpPost]
        public IActionResult Details( Production updatedProduction)
        {
            Production production = _context.productions.Where(p => p.Id == updatedProduction.Id).FirstOrDefault();
            if (production != null)
            {
                production.Name = updatedProduction.Name;
                production.Type = updatedProduction.Type;
                _context.productions.Update(production);
                _context.SaveChanges();
                return View("Update");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Delete(int id)
        {
            Production production = _context.productions.FirstOrDefault(p => p.Id == id);
            if (production != null)
            {
                _context.productions.Remove(production);
                _context.SaveChanges();
            }
            return View();
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
