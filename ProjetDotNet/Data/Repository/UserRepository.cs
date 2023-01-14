using ProjetDotNet.Data.Context;
using ProjetDotNet.Models;
using System.Linq.Expressions;

namespace ProjetDotNet.Data.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(AppDbContext _applicationDbContext) : base(_applicationDbContext)
        {
        }

        public User? FindById(int id)
        {
            return _applicationDbContext.User.Find(id);
        }

        public User? FindByEmail(string? email)
        {
            List<User> users = _applicationDbContext.User.Where(x => x.Email == email).ToList();
            return users.Count == 0 ? null : users[0];
        }

        public User? FindByCreds(string? email, string? password)
        {
            if (email == null) return null;
            if (password == null) return null;

            User? user = _applicationDbContext.User.FirstOrDefault(
                x => x.Email == email && x.Password == password
            );
            return user;
        }
    }
}