using Microsoft.EntityFrameworkCore;
using ProjetDotNet.Data.Context;
using ProjetDotNet.Models;
using System.Linq.Expressions;

namespace ProjetDotNet.Data.Repository
{
    public class ReplyRepository : Repository<Reply>, IReplyRepository
    {
        public ReplyRepository(AppDbContext _applicationDbContext) : base(_applicationDbContext){}

        public IEnumerable<Reply>? GetByPostId(int id)
        {
            IEnumerable<Reply> replies = _applicationDbContext.Reply.Include(x => x.Author).Where(x => x.Post.Id == id);
            return replies;
        }
        
        public void AcceptReply(int id)
        {
            Reply reply = _applicationDbContext.Reply.Find(id);
            reply.IsAccepted = true;
        }
        public void refuseReply(int id)
        {
            Reply reply = _applicationDbContext.Reply.Find(id);
            reply.IsAccepted = false;
        }

        public void upvoteReply(int id, bool upvote)
        {
            Reply reply = _applicationDbContext.Reply.Find(id);
            if (upvote)
            {
                reply.Upvotes += 1;
            }
            else
            {
                reply.Upvotes -= 1;
            }
        }
        
    }
}
