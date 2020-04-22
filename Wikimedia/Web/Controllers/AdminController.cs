using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            var repo = new UserAccountRepository();
            return View(repo.GetAll());
        }

        [Route("admin/points/{name}")]
        public IActionResult Points(string name)
        {
            var repo = new UserAccountRepository();
            repo.AddPoints(name);
            return Content("UPDATED");
        }
    }
}