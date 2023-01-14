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

        [Route("create")]
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
                return RedirectToAction("index", new { id = post.Id });
            }

            return View();
        }

        [Route("GetMyPosts")]
        [HttpGet]
        public IActionResult GetMyPosts(int userId)
        {
        
            UnitOfWork unitOfWork = new UnitOfWork(AppDbContext.Instance);
            IEnumerable<Post> posts = unitOfWork.Posts.GetPostsByAuthor(userId);
            
            Console.WriteLine("---------------------");
            Console.WriteLine(userId);
            Console.WriteLine("---------------------");
            
            ViewBag.posts = posts;
            ViewBag.user = unitOfWork.Users.Get(userId);

            return View();
        }

        [Route("delete")]
        [HttpGet]
        public IActionResult DeletePost(int id)
        {
            User user = (User)HttpContext.Items["user"]!;
            UnitOfWork unitOfWork = new UnitOfWork(AppDbContext.Instance);

            Post? post = unitOfWork.Posts.Get(id);
            if (post == null)
            {
                ViewData["ErrorMsg"] = "Invalid post id!";
                return View("Error");
            }

            if (post.Author.Id != user.Id)
            {
                ViewData["ErrorMsg"] = "You can't delete this post!";
                return View("Error");
            }

            IEnumerable<Reply> replies = unitOfWork.Replies.GetByPostId(post.Id) ?? new List<Reply>();

            unitOfWork.Posts.Remove(post);
            foreach(Reply reply in replies)
            {
                unitOfWork.Replies.Remove(reply);
            }
            unitOfWork.Complete();
            return RedirectToAction("GetMyPosts");
        }

        [Route("upvotePost")]
        public IActionResult upvoteReply(bool isPositive, int postId)
        {
            UnitOfWork unitOfWork = new UnitOfWork(AppDbContext.Instance);
            unitOfWork.Posts.upvotePost(postId, isPositive);
            unitOfWork.Complete();
            return RedirectToAction("Index", "Post", new { id = postId });
        }
    }
}
