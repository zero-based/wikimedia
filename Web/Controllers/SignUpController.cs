using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class SignUpController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(UserAccount userAccount)
        {
            return !ModelState.IsValid ? (ActionResult) View("Index", userAccount) : Content("Sign Up Done !");
        }

    }
}
