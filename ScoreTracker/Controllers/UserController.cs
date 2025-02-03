using Microsoft.AspNetCore.Mvc;
using static ScoreTracker.Models.GameModels;

namespace ScoreTracker.Controllers
{
    public class UserController : Controller
    {
        private readonly DataContext context;

        public UserController(DataContext context)
        {
            this.context = context;
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
            context.Users.Add(user);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
