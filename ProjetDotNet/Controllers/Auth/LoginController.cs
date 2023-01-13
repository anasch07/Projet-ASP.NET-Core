using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetDotNet.Data;
using ProjetDotNet.Models;

namespace ProjetDotNet.Controllers.Auth
{
    [Route("login")]
    public class LoginController : Controller
    {
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("")]
        public IActionResult Process(string? email, string? password)
        {
            User? user = UserRepository.FindByCreds(email, password);
            if (user == null)
            {
                ViewBag.error = "Invalid login.";
                return View("index");
            }

            HttpContext.Session.SetString("userid", user.Id.ToString());
            return RedirectToAction("Index", "Home");
        }
    }
}
