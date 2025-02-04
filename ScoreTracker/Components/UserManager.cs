using ScoreTracker.Models;


namespace ScoreTracker.Components
{
    public interface IUserManager
    {
        void AddUser(User user);
        string GetInitialOfUser(int id);
    }

    public class UserManager : IUserManager
    {
        private readonly DataContext context;

        public UserManager(DataContext context)
        {
            this.context = context;
        }

        public void AddUser(string name)
        {
            var User = new User();

            User.Name = name;

            context.Users.Add(User);

            context.SaveChanges();
        }

        public string GetInitialOfUser(int id)
        {
            var user = context.Users.FirstOrDefault(x => x.Id == id);

            return user.Name.Split("", StringSplitOptions.RemoveEmptyEntries)[0];
        }
    }
}
