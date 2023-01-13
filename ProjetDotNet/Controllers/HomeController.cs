using Microsoft.AspNetCore.Mvc;
using ProjetDotNet.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore.Infrastructure;
using ProjetDotNet.Data;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Storage;
using ProjetDotNet.Data.Context;


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
            
            User user = new User();
            user.Email = "oaoaoa@oaoaoa.oaoaoa";
            user.Name = "oaoaoaoaoaoa";
            user.Password = "oaoaoa";

            Post post = new Post();
            post.Author = user;
            post.Content = "hiii";
            post.Title = "hhh";
            post.Date = DateTime.Now;
            
            unitOfWork.Users.Add(user);
            unitOfWork.Posts.Add(post);
            unitOfWork.Complete();



            return View();
        }

       
        
        
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}