using ProjetDotNet.Models;

namespace ProjetDotNet.Data.Repository
{
    public interface IReplyRepository : IRepository<Reply>
    {
        public IEnumerable<Reply>? GetByPostId(int id);
    }
}
