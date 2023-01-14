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
            IEnumerable<Post> res = unitOfWork.Posts.GetAll();
            return View(res);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}