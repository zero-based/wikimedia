using Core.Models;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Web.Util;

namespace Web.Controllers
{
    public class UserController : Controller
    {
        public IActionResult UserProfile()
        {
            return View(AuthController.LoggedInUser);
        }

        [HttpPost]
        public ActionResult Update(UserAccount userAccount)
        {
            if (!ModelState.IsValid)
                return View("UserProfile", userAccount);
            var userAccountRepository = new UserAccountRepository();
            userAccount.Password = Security.ToHash(userAccount.Password);
            userAccountRepository.Update(userAccount);
            return RedirectToAction("Index", "Interests");
        }
    }
}