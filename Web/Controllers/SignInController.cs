using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class SignInController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(UserAccount userAccount)
        {
            return !ModelState.IsValid ? (ActionResult) View("Index", userAccount) : Content("Sign In Done !");
        }

    }
}
