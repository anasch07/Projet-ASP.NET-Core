using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ProjetDotNet.Data.Context;
using ProjetDotNet.Models;


namespace ProjetDotNet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            UnitOfWork unitOfWork = new UnitOfWork(AppDbContext.Instance);
            
            // User user1 = new User();
            // user1.Email = "user1@user1.com";
            // user1.Name = "user1";
            // user1.Password = "user1";
            //
            // User user2 = new User();
            // user2.Email = "user2@user1.com";
            // user2.Name = "user2";
            // user2.Password = "user2";
            //
            //
            // User user3 = new User();
            // user3.Email = "user3@user.com";
            // user3.Name = "user3";
            // user3.Password = "user3";
            //
            //
            // User user4 = new User();
            // user4.Email = "user4@user.com";
            // user4.Name = "user4";
            // user4.Password = "user4";
            //
            //
            // Post post1 = new Post();
            // post1.Title = "post1";
            // post1.Content = "post1";
            // post1.Author = user1;
            //
            // Post post2 = new Post();
            // post2.Title = "post2";
            // post2.Content = "post2";
            // post2.Author = user2;
            //
            // Post post3 = new Post();
            // post3.Title = "post3";
            // post3.Content = "post3";
            // post3.Author = user3;
            //
            // Post post4 = new Post();
            // post4.Title = "post4";
            // post4.Content = "post4";
            // post4.Author = user4;
            //
            // Reply reply1 = new Reply();
            // reply1.Content = "reply1";
            // reply1.Author = user1;
            // reply1.Post = post1;
            //
            // Reply reply2 = new Reply();
            // reply2.Content = "reply2";
            // reply2.Author = user2;
            // reply2.Post = post2;
            //
            // Reply reply3 = new Reply();
            // reply3.Content = "reply3";
            // reply3.Author = user3;
            // reply3.Post = post3;
            //
            // Reply reply4 = new Reply();
            // reply4.Content = "reply4";
            // reply4.Author = user4;
            // reply4.Post = post4;
            //
            // unitOfWork.Users.Add(user1);
            // unitOfWork.Users.Add(user2);
            // unitOfWork.Users.Add(user3);
            // unitOfWork.Users.Add(user4);
            //
            // unitOfWork.Posts.Add(post1);
            // unitOfWork.Posts.Add(post2);
            // unitOfWork.Posts.Add(post3);
            // unitOfWork.Posts.Add(post4);
            
            // unitOfWork.ReplyRepository.Add(reply1);
            // unitOfWork.ReplyRepository.Add(reply2);
            // unitOfWork.ReplyRepository.Add(reply3);
            // unitOfWork.ReplyRepository.Add(reply4);
            //
       

            // unitOfWork.Complete();






            return View();
        }

       
        
        
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}