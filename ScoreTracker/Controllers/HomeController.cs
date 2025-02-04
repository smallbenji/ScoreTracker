using Microsoft.AspNetCore.Mvc;
using ScoreTracker.Models;

namespace ScoreTracker.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext context;

        public HomeController(DataContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
