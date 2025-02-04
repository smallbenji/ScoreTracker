using static ScoreTracker.Models.GameModels;

namespace ScoreTracker.Components
{
    public interface ITeamManager
    {
        void AddTeam(string name, List<User> Users);
        void RemoveTeam(int id);
    }

    public class TeamManager : ITeamManager
    {
        private readonly DataContext context;

        public TeamManager(DataContext context)
        {
            this.context = context;
        }

        public void AddTeam(string name, List<User> Users)
        {
            var team = new Team();

            team.Users = Users;

            context.Teams.Add(team);

            context.SaveChanges();
        }

        public void RemoveTeam(int id)
        {
            var team = context.Teams.FirstOrDefault(x => x.Id == id);

            if (team != null)
            {
                context.Teams.Remove(team);
                context.SaveChanges();

                return;
            }

            throw new Exception("Team not found");
        }
    }
}
