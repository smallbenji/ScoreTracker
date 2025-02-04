using Microsoft.AspNetCore.Mvc;
using ScoreTracker.Components;
using ScoreTracker.Models;

namespace ScoreTracker.Controllers
{
    public class UserController : Controller
    {
        private readonly DataContext context;
        private readonly IUserManager userManager;

        public UserController(DataContext context, IUserManager userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            var vm = context.Users.ToList();

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
