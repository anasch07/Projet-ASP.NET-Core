using Microsoft.AspNetCore.Mvc;
using ProjetDotNet.Models;
using System.Diagnostics;
using ProjetDotNet.Data;
using Microsoft.EntityFrameworkCore.Query;


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

            AppDbContext appDbContext = AppDbContext.Instantiate_AppDbContext();
            Console.WriteLine("AppDbContext instantiated {0}  times", AppDbContext.count);

            
            //create a new user
            User user = new User();

            user.Email = "aa@cc.cc";
            user.Name= "aa";
            user.Password = "aa";
            
            //add the user to the database
            appDbContext.Users.Add(user);
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