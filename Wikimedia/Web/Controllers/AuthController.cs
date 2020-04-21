using Core.Models;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Web.Util;

namespace Web.Controllers
{
    public class AuthController : Controller
    {
        public static UserAccount LoggedInUser { get; set; }
        public IActionResult SignUp()
        {
            return View();
        }

        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(UserAccount userAccount)
        {
            var isEmailValid = ModelState.GetFieldValidationState("Email") == ModelValidationState.Valid;
            var isPasswordValid = ModelState.GetFieldValidationState("Password") == ModelValidationState.Valid;
            if (!isEmailValid && !isPasswordValid)
                return View("SignIn", userAccount);
            var userAccountRepository = new UserAccountRepository();
            var dbUser = userAccountRepository.Get(userAccount.Email);
            if (dbUser.Password == Security.ToHash(userAccount.Password))
            {
                LoggedInUser = dbUser;
                return RedirectToAction("Index", "Topics");
            }
            return View("SignIn");
        }

        [HttpPost]
        public ActionResult SignUp(UserAccount userAccount)
        {
            if (!ModelState.IsValid)
                return View("SignUp", userAccount);
            var userAccountRepository = new UserAccountRepository();
            userAccount.Password = Security.ToHash(userAccount.Password);
            userAccountRepository.Create(userAccount);
            LoggedInUser = userAccount;
            return RedirectToAction("Interests", "User");
        }

    }
}
