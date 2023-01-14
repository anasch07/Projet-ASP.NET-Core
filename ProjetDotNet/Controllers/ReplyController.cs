using Microsoft.AspNetCore.Mvc;
using ProjetDotNet.Data.Context;
using ProjetDotNet.Data.Repository;
using ProjetDotNet.Models;

namespace ProjetDotNet.Controllers
{
    [Route("reply")]
    public class ReplyController : Controller
    {

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