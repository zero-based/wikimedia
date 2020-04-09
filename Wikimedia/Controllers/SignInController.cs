using System.Web.Mvc;

namespace Wikimedia.Controllers
{
    public class SignInController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SignIn()
        {
            return Content("Sign In Done !");
        }
        
    }
}
