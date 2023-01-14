using Microsoft.AspNetCore.Mvc;
using ProjetDotNet.Data;
using ProjetDotNet.Data.Context;
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
                ViewBag.error = "Invalid Registration Check Your Data   .";
                return View("index");
            }

            UnitOfWork unitOfWork = new UnitOfWork(AppDbContext.Instance);
            if(unitOfWork.Users.FindByEmail(user.Email) != null)
            {
                ViewData["ErrorMsg"] = "Email already in use!";
                return View("Error");
            }

            unitOfWork.Users.Add(user);
            unitOfWork.Complete();

            return RedirectToAction("login", "auth");
        }
    }
}
