using static ScoreTracker.Models.GameModels;

namespace ScoreTracker.Components
{
    public class GameManager
    {
        private readonly DataContext context;

        public GameManager(DataContext context)
        {
            this.context = context;
        }

        public void CreateGame(List<Team> Teams)
        {
            var Game = new Game();

            Game.Teams = Teams;

            context.Games.Add(Game);

            context.SaveChanges();
        }

        public void AddPoint(User user, int Point)
        {

        }
    }
}
