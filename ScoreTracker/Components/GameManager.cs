using Microsoft.EntityFrameworkCore;
using ScoreTracker.Models;

namespace ScoreTracker.Components
{
    public interface IGameManager
    {
        void CreateGame(List<Team> Teams);
        void AddPoint(User user, int Point);
        List<Game> GetAll();
        void RemoveGame(int id);
    }

    public class GameManager : IGameManager
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

        public List<Game> GetAll()
        {
            return context.Games.Include(o => o.Teams).ToList();
        }

        public void RemoveGame(int id)
        {
            var game = context.Games.FirstOrDefault(x => x.Id == id);

            if (game != null)
            {
                context.Games.Remove(game);
                context.SaveChanges();

                return;
            }

            throw new Exception("Game not found");
        }
    }
}
