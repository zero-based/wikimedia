using System.Collections.Generic;
using System.Linq;
using Core.Models;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Web.Util;
using Web.ViewModels;

namespace Web.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Settings()
        {
            return View(AuthController.LoggedInUser);
        }

        [HttpGet]
        public ActionResult Interests()
        {
            var username = AuthController.LoggedInUser.Username;
            var interests = new InterestsRepository().GetAll();
            var userInterestsIds = new UserAccountRepository().GetInterests(username).ToDictionary(i => i.Id);
            var interestViewModels = interests.Select(i => new InterestViewModel
            {
                Interest = i,
                IsChecked = userInterestsIds.ContainsKey(i.Id)
            });

            return View(interestViewModels.ToList());
        }

        [HttpPost]
        public ActionResult Update(UserAccount userAccount)
        {
            if (!ModelState.IsValid)
                return View("Settings", userAccount);
            var userAccountRepository = new UserAccountRepository();
            userAccount.Password = Security.ToHash(userAccount.Password);
            userAccountRepository.Update(userAccount);
            return RedirectToAction("Interests", "User");
        }

        [HttpPost]
        public IActionResult UpdateInterests(List<InterestViewModel> interestViewModels)
        {
            var userRepository = new UserAccountRepository();
            userRepository.UpdateUserInterests(
                interestViewModels.Where(ivm => ivm.IsChecked).Select(ivm => ivm.Interest).ToList(),
                AuthController.LoggedInUser.Username);
            return RedirectToAction("Index", "Topics");
        }
    }
}