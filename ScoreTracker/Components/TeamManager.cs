using static ScoreTracker.Models.GameModels;

namespace ScoreTracker.Components
{
    public class TeamManager
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
