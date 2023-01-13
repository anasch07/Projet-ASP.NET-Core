using ProjetDotNet.Models;

namespace ProjetDotNet.Data.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        public User? FindByCreds(string? email, string? password);
        public User? FindById(int id);
    }
}