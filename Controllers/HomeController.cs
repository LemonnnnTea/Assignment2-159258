using Microsoft.AspNetCore.Mvc;

namespace MyArchiveProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(); // ·µ»Ø Views/Home/Index.cshtml
        }
    }
}