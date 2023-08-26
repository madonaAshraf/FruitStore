using fruit.Data;
using fruit.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace fruit.Controllers
{
	[Route("[controller]")]
	public class AccountController : Controller
    {


        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }
      
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost("Create")]
        public IActionResult Create(Account account)
        {
           
            if (ModelState.IsValid)
            {
               
               _context.Accounts.Add(account);
               _context.SaveChanges();

            }
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("logIn")]
        public IActionResult Login ( string email, string password)
        {

            var Account = _context.Accounts.FirstOrDefault(c => c.email== email && c.password == password);
            if (Account == null)
            {
                return NotFound();
            }


            return RedirectToAction("Index", "Home");

        }


    }
}