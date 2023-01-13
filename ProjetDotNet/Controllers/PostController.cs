using Microsoft.AspNetCore.Mvc;
using ProjetDotNet.Data.Context;
using ProjetDotNet.Data.Repository;
using ProjetDotNet.Models;

namespace ProjetDotNet.Controllers
{
    [Route("post")]
    public class PostController : Controller
    {
        public IActionResult Index(int id)
        {
            if (id == null)
            {
                ViewBag.error = "post not found";
                return View(null);
            }

            PostRepository postRepository = new PostRepository(AppDbContext.Instance);

            Post? post = postRepository.Get(id);
            if (post == null)
            {
                ViewBag.error = "post not found";
                return View(null);
            }

            //get post replies
            UnitOfWork unitOfWork = new UnitOfWork(AppDbContext.Instance);

            IEnumerable<Reply>? replies = unitOfWork.Replies.GetByPostId(id);

            ViewData["replies"] = replies;
            return View(post);
        }
    }
}
