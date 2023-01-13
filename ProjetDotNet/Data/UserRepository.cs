using ProjetDotNet.Models;

namespace ProjetDotNet.Data
{
    public class UserRepository
    {
        public static User? FindById(int id)
        {
            AppDbContext context = AppDbContext.Instance;

            User? user = context.User.Find(id);
            return user;
        }

        public static void CreateUser(User user)
        {
            AppDbContext appDbContext = AppDbContext.Instance;
            appDbContext.User.Add(user);
            appDbContext.SaveChanges();
        }

        public static User? FindByCreds(string? email, string? password)
        {
            if (email == null) return null;
            if (password == null) return null;

            AppDbContext context = AppDbContext.Instance;

            User? user = context.User.FirstOrDefault(
                x => x.Email == email && x.Password == password
            );
            return user;
        }
    }
}
