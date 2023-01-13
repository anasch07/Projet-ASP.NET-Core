using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetDotNet.Data;

namespace ProjetDotNet.Controllers.Auth
{
    [Route("login")]
    public class LoginController : Controller
    {
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }

        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // [Route("process")]
        // public IActionResult Process(string? username, string? password)
        // {
        //     object? user = UserRepository.FindByCreds(username, password);
        //     if (user == null)
        //     {
        //         ViewBag.error = "Invalid login.";
        //         return RedirectToAction("Index");
        //     }
        //
        //     HttpContext.Session.SetString("username", username!);
        //     return RedirectToAction("Index", "Home");
        // }
    }
}
