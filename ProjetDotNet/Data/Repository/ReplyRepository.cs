using ProjetDotNet.Data.Context;
using ProjetDotNet.Models;
using System.Linq.Expressions;

namespace ProjetDotNet.Data.Repository
{
    public class ReplyRepository : Repository<Reply>, IReplyRepository
    {
        public ReplyRepository(AppDbContext _applicationDbContext) : base(_applicationDbContext)
        {
        }
    }
}