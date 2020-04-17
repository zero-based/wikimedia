using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult SignUp()
        {
            return View();
        }

        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignInSubmit(UserAccount userAccount)
        {
            return !ModelState.IsValid ? (ActionResult)View("SignIn", userAccount) : Content("Sign In Done !");
        }

        [HttpPost]
        public ActionResult SignUpSubmit(UserAccount userAccount)
        {
            return !ModelState.IsValid ? (ActionResult)View("SignUp", userAccount) : Content("Sign Up Done !");
        }

    }
}
