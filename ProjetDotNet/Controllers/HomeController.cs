using Microsoft.AspNetCore.Mvc;
using ProjetDotNet.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore.Infrastructure;
using ProjetDotNet.Data;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Storage;


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

            AppDbContext appDbContext = AppDbContext.Instance;
            Console.WriteLine("AppDbContext instantiated in HomeController");
            
            User user = new User();
            user.Name = "Mongi";
            user.Email = "Mongi@Mongi.cc";
            user.Password = "a*a*";
            
            Post post = new Post();
            post.Title = "My Second post";
            post.Content = "This is my Second post";
            post.Author = user;
            post.Date = DateTime.Now;
            
            Reply reply = new Reply();
            reply.Content = "This is my Second reply";
            reply.Author = user;
            reply.Date = DateTime.Now;
            reply.Post = post;
            reply.IsAccepted = true;
            
            
            
            appDbContext.User.Add(user);
            appDbContext.Post.Add(post);
            appDbContext.Reply.Add(reply);
            appDbContext.SaveChanges();



            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}