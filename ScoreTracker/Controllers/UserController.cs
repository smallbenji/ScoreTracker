using Microsoft.AspNetCore.Mvc;
using ScoreTracker.Components;
using ScoreTracker.Models;

namespace ScoreTracker.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserManager userManager;

        public UserController (
            IUserManager userManager
        )
        {
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            var vm = userManager.GetAll();

            return View(vm);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            userManager.AddUser(user);

            return RedirectToAction("Index");
        }
    }
}
