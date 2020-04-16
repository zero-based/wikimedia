using Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Web.Controllers
{
    public class TopicsController : Controller
    {
        private static readonly Topic CachedTopic = new Topic
        {
            Name = "CachedTopic",
            FilePath = "/",
            Creator = new UserAccount { Username = "zero-based" },
            UpVotes = 100,
            DownVotes = 5,
            Body = "**Lorem ipsum** dolor sit amet, consectetur adipiscing elit," +
                   "sed do eiusmod tempor _incididunt_ ut labore et dolore magna "
        };

        private static readonly Topic UncachedTopic = new Topic
        {
            Name = "UncachedTopic",
            FilePath = "/",
            Creator = new UserAccount { Username = "zero-based" },
            UpVotes = 100,
            DownVotes = 5,
            Body = "**Lorem ipsum** dolor sit amet, consectetur adipiscing elit," +
                   "sed do eiusmod tempor _incididunt_ ut labore et dolore magna "
        };

        private readonly Dictionary<string, Topic> _pool = new Dictionary<string, Topic>
        {
            {"CachedTopic", CachedTopic}
        };

        public ActionResult Index()
        {
            return View(_pool.Values);
        }

        [Route("topics/{name}")]
        public ActionResult TopicByName(string name)
        {
            return View(_pool.ContainsKey(name) ? _pool[name] : UncachedTopic);
        }
    }
}