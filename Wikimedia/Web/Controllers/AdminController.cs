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
    }
}