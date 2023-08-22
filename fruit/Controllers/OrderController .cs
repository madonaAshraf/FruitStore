using fruit.Data;
using fruit.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace fruit.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderController(ApplicationDbContext context)
        {
            _context = context;





        }
        public IActionResult Index()
        {
            var category = _context.Categories.ToList();
            return View(category);
        }


        [HttpGet("create")]
        public IActionResult Create(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }





    }
}