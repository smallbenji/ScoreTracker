using Microsoft.AspNetCore.Mvc;

namespace ScoreTracker.Controllers
{
    public class TeamController : Controller
    {
        private readonly DataContext context;

        public TeamController(DataContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var vm = context.Teams.ToList();

            return View(vm);
        }

        public IActionResult Create()
        {
            var vm = context.Users.ToList();

            return View(vm);
        }
    }
}
