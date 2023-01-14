using ProjetDotNet.Models;

namespace ProjetDotNet.Data.Repository{

    public interface IPostRepository : IRepository<Post>

    {
        public new IEnumerable<Post> GetAll();
    }
}