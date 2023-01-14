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
        public IActionResult CreateReply(int postId, string content)
        {
            User user = (User)HttpContext.Items["user"]!;

            UnitOfWork unitOfWork = new UnitOfWork(AppDbContext.Instance);
            Post? post = unitOfWork.Posts.Get(postId);
            if (post == null || content == null)
            {
                return BadRequest();
            }

            Reply reply = new Reply();
            Console.WriteLine(post.Id + ' ' + user.Id);
            reply.Post = post;
            reply.Author = user;
            reply.Content = content;
            reply.Date = DateTime.Now;

            unitOfWork.Replies.Add(reply);
            unitOfWork.Complete();
            return RedirectToAction("index", "post", new { id = postId });

        }

        [Route ("acceptReply")]
        public  IActionResult acceptReply(int postId, int replyId)
        {
            UnitOfWork unitOfWork = new UnitOfWork(AppDbContext.Instance);
            unitOfWork.Replies.AcceptReply(replyId);
            unitOfWork.Complete();
            return RedirectToAction("Index", "Post", new { id = postId });
        }
        
        [Route ("refuseReply")]
        public  IActionResult refuseReply(int postId, int replyId)
        {
            UnitOfWork unitOfWork = new UnitOfWork(AppDbContext.Instance);
            unitOfWork.Replies.refuseReply(replyId);
            unitOfWork.Complete();
            return RedirectToAction("Index", "Post", new { id = postId });
        }
        
        
    }
    
}