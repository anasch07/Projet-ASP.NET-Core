using Microsoft.EntityFrameworkCore;
using ProjetDotNet.Data.Context;
using ProjetDotNet.Models;
using System.Linq.Expressions;

namespace ProjetDotNet.Data.Repository
{
    public class ReplyRepository : Repository<Reply>, IReplyRepository
    {
        public ReplyRepository(AppDbContext _applicationDbContext) : base(_applicationDbContext){}

        public bool Add(Reply entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Reply> Find(Expression<Func<Reply, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Reply? Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Reply> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Remove(Reply entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Reply>? GetByPostId(int id)
        {
            IEnumerable<Reply> replies = _applicationDbContext.Reply.Include(x => x.Author).Where(x => x.Post.Id == id);
            return replies;
        }
    }
}
