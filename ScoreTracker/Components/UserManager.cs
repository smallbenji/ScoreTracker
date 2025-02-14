using Microsoft.EntityFrameworkCore;
using ScoreTracker.Models;


namespace ScoreTracker.Components
{
    public interface IUserManager
    {
        List<User> GetAll();
        User GetUser(int id);
        void AddUser(User user);
        string GetInitialOfUser(int id);
        void RemoveUser(int id);
        void UpdateUser(User user);
    }

    public class UserManager : IUserManager
    {
        private readonly DataContext context;

        public UserManager(DataContext context)
        {
            this.context = context;
        }

        public List<User> GetAll()
        {
            return context.Users.Include(o => o.Teams).ToList();
        }

        public User GetUser(int id)
        {
            return context.Users.FirstOrDefault(x => x.Id.Equals(id));
        }

        public void AddUser(User user)
        {
            context.Users.Add(user);

            context.SaveChanges();
        }

        public string GetInitialOfUser(int id)
        {
            var user = context.Users.FirstOrDefault(x => x.Id == id);

            return user.Name.Split("", StringSplitOptions.RemoveEmptyEntries)[0];
        }

        public void RemoveUser(int id)
        {
            // Find user
            var user = context.Users.FirstOrDefault(x => x.Id.Equals(id));

            context.Users.Remove(user);

            context.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            context.Users.Update(user);

            context.SaveChanges();
        }
    }
}
