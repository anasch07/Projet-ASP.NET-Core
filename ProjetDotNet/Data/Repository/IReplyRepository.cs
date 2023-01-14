using ProjetDotNet.Models;

namespace ProjetDotNet.Data.Repository
{
    public interface IReplyRepository : IRepository<Reply>
    {
        public IEnumerable<Reply>? GetByPostId(int id);
        public void AcceptReply(int id);
        public void refuseReply(int id);
        public void upvoteReply(int id, bool up);
    }
}
