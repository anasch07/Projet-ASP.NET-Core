using Microsoft.AspNetCore.Mvc;
using ProjetDotNet.Data.Context;
using ProjetDotNet.Data.Repository;
using ProjetDotNet.Models;

namespace ProjetDotNet.Controllers
{
    [Route("reply")]
    public class ReplyController : Controller
    {
        [HttpPost]
        [HttpGet]
        [Route("create")]
        public IActionResult CreateReply(int postId, string content)
        {
            User user = (User) HttpContext.Items["user"]!;
            if(HttpContext.Request.Method == "POST")
            {
                UnitOfWork unitOfWork = new UnitOfWork(AppDbContext.Instance);
                Post? post = unitOfWork.Posts.Get(postId);
                if(post == null || content == null)
                {
                    return BadRequest();
                }

                Reply reply = new Reply();
                reply.Post = post;
                reply.Author = user;
                reply.Content = content;
                reply.Date = DateTime.Now;

                unitOfWork.Replies.Add(reply);
                unitOfWork.Complete();
                return RedirectToAction("create");
            }

            UnitOfWork unitOfWork2 = new UnitOfWork(AppDbContext.Instance);
            
            return View(unitOfWork2.Posts.Get(1)!);
        }
    }
}
