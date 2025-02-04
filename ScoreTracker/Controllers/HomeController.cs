using Microsoft.AspNetCore.Mvc;
using ScoreTracker.Models;

namespace ScoreTracker.Controllers
{
    public class HomeController : Controller
    {
        public HomeController (

        )
        {

        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
