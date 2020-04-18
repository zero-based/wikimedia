using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Web.ViewModels;

namespace Web.Controllers
{
    public class InterestsController : Controller
    {
        [HttpGet]
        public ActionResult Index()
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
        public IActionResult Update(List<InterestViewModel> interestViewModels)
        {
            var userRepository = new UserAccountRepository();
            userRepository.UpdateUserInterests(
                interestViewModels.Where(ivm => ivm.IsChecked).Select(ivm => ivm.Interest).ToList(),
                AuthController.LoggedInUser.Username);
            return RedirectToAction("Index", "Home");
        }
    }
}