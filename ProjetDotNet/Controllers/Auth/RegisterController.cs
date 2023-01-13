using Microsoft.AspNetCore.Mvc;

namespace ProjetDotNet.Controllers.Auth
{
    [Route("register")]
    public class RegisterController : Controller
    {
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("process")]
        public IActionResult Process(object user)
        {
            if (!Helper.Helper.IsUserInfoValid(user))
            {
                ViewBag.error = "Invalid login.";
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index", "Login");
        }
    }
}
