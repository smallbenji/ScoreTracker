using Microsoft.AspNetCore.Mvc;
using ScoreTracker.Components;

namespace ScoreTracker.Controllers
{
    public class TeamController : Controller
    {
        private readonly ITeamManager teamManager;
        private readonly IUserManager userManager;

        public TeamController (
            ITeamManager teamManager,
            IUserManager userManager
        )
        {
            this.teamManager = teamManager;
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            var vm = teamManager.GetAll();

            return View(vm);
        }

        public IActionResult Create()
        {
            var vm = userManager.GetAll();

            return View(vm);
        }
    }
}
