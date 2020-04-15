using System.Web.Mvc;
using Wikimedia.Models;

namespace Wikimedia.Controllers
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
            if (!ModelState.IsValid)
                return View("Index", userAccount);
            return Content("Sign In Done !");
        }

    }
}
