using Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Web.Controllers
{
    public class CommitsController : Controller
    {
        // GET: Commit
        public ActionResult Index()
        {
            var commits = new List<Commit>
            {
                new Commit
                {
                    Author = new UserAccount {Username = "YoussefRaafatNassry"},
                    Date = DateTime.Now,
                    Message = "Add Topics View & Controller"
                },
                new Commit
                {
                    Author = new UserAccount {Username = "MonicaTanios"},
                    Date = DateTime.Now,
                    Message = "Add SignIn/Up Views & Controllers"
                }
            };

            return View(commits);
        }

    }
}