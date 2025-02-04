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
            var vm = new HomeViewModel();

            vm.Teams = context.Teams.ToList();

            return View(vm);
        }
    }

    public class HomeViewModel
    {
        public List<Team> Teams { get; set; }
    }
}
