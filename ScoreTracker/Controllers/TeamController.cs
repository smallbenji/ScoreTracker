using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ScoreTracker.Components;
using ScoreTracker.Models;

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

            var users = new List<SelectListItem>();

            users.AddRange(vm.Select(o => new SelectListItem()
            {
                Text = o.Name,
                Value = o.Id.ToString(),
            }));

            ViewBag.Users = users;

            return View();
        }

        [HttpPost]
        public IActionResult Create(TeamCreate team)
        {
            var usersSelected = new List<User>();

            foreach (var item in team.Users )
            {
                if (int.TryParse(item, out var i))
                {
                    try
                    {
                        usersSelected.Add(userManager.GetUser(i));
                    }
                    catch
                    {
                        return StatusCode(StatusCodes.Status400BadRequest, "Error happened while trying to find user");
                    }
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Could not parse integer");
                }

            }

            teamManager.AddTeam(team.Name, usersSelected);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var vm = teamManager.GetTeam(id);

            return View(vm);
        }
        public IActionResult Delete(int id)
        {
            teamManager.RemoveTeam(id);

            return RedirectToAction(nameof(Index));
        }
    }

    public class TeamCreate
    {
        public string Name { get; set; }
        public List<string> Users { get; set; }
    }
}
