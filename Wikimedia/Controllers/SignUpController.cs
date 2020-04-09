using System.Web.Mvc;

namespace Wikimedia.Controllers
{
    public class SignUpController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SignUp()
        {
            return Content("Sign up done !");
        }

    }
}
