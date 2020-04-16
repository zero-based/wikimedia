using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class InterestsController : Controller
    {
        // GET: Interests
        public ActionResult Index()
        {
            return View(new Demo().GetAll());
        }
    }
}