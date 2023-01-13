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
            
            User user = new User();
            user.Email = "paapap@oaoaoa.oaoaoa";
            user.Name = "paapap";
            user.Password = "oaoaoa";
            
            unitOfWork.Users.Add(user);
            unitOfWork.Complete();


            // AppDbContext appDbContext = AppDbContext.Instance;
            //
            //
            // User user = new User();
            // user.Name = "wawawa";
            // user.Email = "wawawa@wawawa.cc";
            // user.Password = "wawawa";
            //
            // appDbContext.User.Add(user);
            // appDbContext.SaveChanges();
            

            return View();
        }

       
        
        
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}