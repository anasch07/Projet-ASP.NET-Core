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
            return RedirectToAction("index", new { id=postId } );
            
        }
        
        
        [Route ("create")]
        public IActionResult CreatePost(Post post)
        {
            User user = (User)HttpContext.Items["user"]!;
            Console.WriteLine("Exec!");
            if (HttpContext.Request.Method == "POST")
            {
                UnitOfWork unitOfWork = new UnitOfWork(AppDbContext.Instance);
                post.Author = user;
                post.Date = DateTime.Now;
                unitOfWork.Posts.Add(post);
                unitOfWork.Complete();
                return RedirectToAction("index", new { id=post.Id } );
            }

            return View();
        }
        
        [Route ("GetMyPosts")]
        [HttpGet]
        public IActionResult GetMyPosts()
        {
            User user = (User)HttpContext.Items["user"]!;
            UnitOfWork unitOfWork = new UnitOfWork(AppDbContext.Instance);
            IEnumerable<Post> posts = unitOfWork.Posts.GetPostsByAuthor(user.Id);
            
            ViewBag.posts = posts;
            ViewBag.user = user;
            
            return View();
        }
        
        
        
    }
}
