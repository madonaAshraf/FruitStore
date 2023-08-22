using Microsoft.AspNetCore.Mvc;

namespace fruit.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
