using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Wikimedia.Models;

namespace Wikimedia.Controllers
{
    public class CommitsController : Controller
    {
        // GET: Commit
        public ActionResult Index()
        {
            var commits = getCommits();
            return View(commits);
        }

        public IEnumerable<Commit> getCommits()
        {
            return new List<Commit>
            {
                new Commit
                {
                    Author =new UserAccount {Username = "YoussefRaafatNassry"}, Date = DateTime.Now, Message = "Add Topics View & Controller"
                },
                new Commit { Author=new UserAccount {Username = "MonicaTanios"}, Date = DateTime.Now, Message = "Add SignIn/Up Views & Controllers"}
            };
        }
    }
}