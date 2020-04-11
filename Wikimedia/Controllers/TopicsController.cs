using System.Web.Mvc;
using Wikimedia.Models;

namespace Wikimedia.Controllers
{
    public class TopicsController : Controller
    {
        [Route("topics/{name}")]
        public ActionResult Index(string name)
        {
            var tmpTopic = new Topic
            {
                Name = name,
                FilePath = "/",
                Creator = new UserAccount { Username = "zero-based" },
                UpVotes = 100,
                DownVotes = 5,
                Body = "**Lorem ipsum** dolor sit amet, consectetur adipiscing elit," +
                       "sed do eiusmod tempor _incididunt_ ut labore et dolore magna " +
                       "aliqua. Ut enim ad minim veniam, quis nostrud exercitation " +
                       "ullamco laboris nisi ut aliquip ex ea commodo consequat. " +
                       "Duis aute irure dolor in reprehenderit in voluptate velit " +
                       "esse cillum dolore eu fugiat nulla pariatur. Excepteur sint " +
                       "occaecat cupidatat non proident, sunt in culpa qui officia " +
                       "deserunt mollit anim id est laborum.\n\n" +
                       " - List item\n" +
                       " - List item\n" +
                       " - List item\n"
            };

            return View(tmpTopic);
        }
    }
}