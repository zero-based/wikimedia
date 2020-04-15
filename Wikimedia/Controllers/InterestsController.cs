using System.Collections.Generic;
using System.Web.Mvc;
using Core.Models;
using Infrastructure;

namespace Web.Controllers
{
    public class InterestsController : Controller
    {
        // GET: Interests
        public ActionResult Interests()
        {
            var interests = new List<Interest>
            {
                new Interest {Id = 1, Name = "Interest 1"},
                new Interest {Id = 2, Name = "Interest 2"},
                new Interest {Id = 3, Name = "Interest 3"},
                new Interest {Id = 4, Name = "Interest 4"},
                new Interest {Id = 5, Name = "Interest 5"}
            };

            return View(new Demo().GetAll());
        }
    }
}