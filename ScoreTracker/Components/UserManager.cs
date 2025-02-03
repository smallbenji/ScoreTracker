using static ScoreTracker.Models.GameModels;


namespace ScoreTracker.Components
{
    public class UserManager
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
