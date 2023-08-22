using fruit.Data;
using fruit.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace fruit.Controllers
{
    public class ProductController : Controller
    {


        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var category = _context.Categories.ToList();
            return View(category);
        }
        [HttpGet(" Details/{id}")]
        public IActionResult Detials(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = _context.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);

        }
        [HttpGet("create")]
        public IActionResult Create(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }

        [HttpGet("edit/{id}")]
        public IActionResult Edit(int id)
        {


            if (id == null)
            {
                return NotFound();
            }

            var category = _context.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);

        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {


            if (category.Id == 0)

            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _context.Update(category);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));

            }

            return View(category);

        }
        [HttpGet(" delete/{id}")]
        public IActionResult Delete(int id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var category = _context.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);

        }
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == id);

            _context.Categories.Remove(category);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}