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

            AppDbContext appDbContext = AppDbContext.Instance;
            Console.WriteLine("AppDbContext instantiated in HomeController");

            
            //create a new user
            User user = new User();

            user.Email = "aa@cc.cc";
            user.Name= "aa";
            user.Password = "aa";
            
            
            
            



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