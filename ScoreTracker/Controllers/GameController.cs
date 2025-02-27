using Microsoft.AspNetCore.Mvc;
using ScoreTracker.Components;

namespace ScoreTracker.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameManager gameManager;

        public GameController (
            IGameManager gameManager
        )
        {
            this.gameManager = gameManager;
        }

        public IActionResult Index()
        {
            
            return View();
        }
    }
}
