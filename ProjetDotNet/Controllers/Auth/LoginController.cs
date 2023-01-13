using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetDotNet.Data;
using ProjetDotNet.Data.Context;
using ProjetDotNet.Data.Repository;
using ProjetDotNet.Models;

namespace ProjetDotNet.Controllers.Auth
{
    [Route("auth")]
    public class LoginController : Controller
    {
        [HttpGet]
        [Route("login")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("login")]
        public IActionResult Process(string? email, string? password)
        {
            UserRepository userRepository = new UserRepository(AppDbContext.Instance);
            User? user = userRepository.FindByCreds(email, password);

            if (user == null)
            {
                ViewBag.error = "Invalid login.";
                return View("index");
            }

            HttpContext.Session.SetString("userid", user.Id.ToString());
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Route("logout")]
        public IActionResult logout()
        {
            HttpContext.Session.Clear();
            Response.Cookies.Delete(".AspNetCore.Session");
            return RedirectToAction("login", "auth");
        }
    }
}
