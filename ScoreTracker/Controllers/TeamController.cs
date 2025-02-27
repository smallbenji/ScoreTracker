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
            var allUsers = userManager.GetAll();

            var users = new List<SelectListItem>();

            users.AddRange(allUsers.Select(o => new SelectListItem()
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
            var team = teamManager.GetTeam(id);

            var vm = new TeamCreate();

            vm.Name = team.Name;

            vm.id = id;

            var allUsers = userManager.GetAll();

            var users = new List<SelectListItem>();

            users.AddRange(allUsers.Select(o => new SelectListItem()
            {
                Text = o.Name,
                Value = o.Id.ToString(),
                Selected = team.Users.Select(x => x.Id).ToList().Exists(x => x == o.Id)
            }));

            ViewBag.Users = users;

            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(TeamCreate team)
        {
            var usersSelected = new List<User>();

            var updatedTeam = teamManager.GetTeam(team.id);

            foreach (var item in team.Users)
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

            updatedTeam.Name = team.Name;
            updatedTeam.Users = usersSelected;

            teamManager.EditTeam(updatedTeam);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            teamManager.RemoveTeam(id);

            return RedirectToAction(nameof(Index));
        }
    }

    public class TeamCreate
    {
        public int id { get; set; }
        public string Name { get; set; }
        public List<string> Users { get; set; }
    }
}
