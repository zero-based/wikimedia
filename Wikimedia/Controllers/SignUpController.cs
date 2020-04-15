using System.Web.Mvc;
using Core.Models;

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
            if (!ModelState.IsValid)
                return View("Index", userAccount);
            return Content("Sign Up Done !");
        }

    }
}
