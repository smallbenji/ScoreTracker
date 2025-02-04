namespace ScoreTracker.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Team> Teams { get; set; }
    }

    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<User> Users { get; set; }
        public List<Game> Games { get; set; }
    }

    public class Game
    {
        public int Id { get; set; }
        public int WinnerTeam { get; set; }
        public List<Team> Teams { get; set; }
        public List<int> Points { get; set; }
        public List<int> DoubleGoals { get; set; }
        public Location Location { get; set; }
        public int TimeElapsed { get; set; }
    }

    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
