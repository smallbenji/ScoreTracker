using Microsoft.AspNetCore.Mvc;

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
