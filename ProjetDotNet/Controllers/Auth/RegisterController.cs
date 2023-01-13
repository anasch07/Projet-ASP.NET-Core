using Microsoft.AspNetCore.Mvc;
using ProjetDotNet.Data;
using ProjetDotNet.Models;

namespace ProjetDotNet.Controllers.Auth
{
    [Route("register")]
    public class RegisterController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("")]
        public IActionResult Process(User user)
        {
            if (!Helper.ValidationHelper.IsUserInfoValid(user))
            {
                ViewBag.error = "Invalid login.";
                return View("index");
            }

            UserRepository.CreateUser(user);
            return RedirectToAction("", "Login");
        }
    }
}
