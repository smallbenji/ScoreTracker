using Microsoft.EntityFrameworkCore;
using static ScoreTracker.Models.GameModels;

namespace ScoreTracker
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Game> Games { get; set; }
    }
}
