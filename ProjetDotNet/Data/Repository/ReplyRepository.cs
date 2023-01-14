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
    }
}
