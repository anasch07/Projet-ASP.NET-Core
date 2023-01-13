using ProjetDotNet.Data.Context;
using ProjetDotNet.Models;
using System.Linq.Expressions;

namespace ProjetDotNet.Data.Repository
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(AppDbContext _applicationDbContext) : base(_applicationDbContext)
        {
        }
    }
}