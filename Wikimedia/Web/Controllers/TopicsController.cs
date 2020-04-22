using Core.Models;
using Infrastructure.Repositories;
using Infrastructure.Storage;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web.Controllers
{
    public class TopicsController : Controller
    {
        private static readonly Dictionary<string, Topic> Cache = new Dictionary<string, Topic>();
        private readonly TopicRepository _topicRepository = new TopicRepository();

        [Route("/")]
        [Route("topics/")]
        public async Task<ActionResult> Index()
        {
            var topics = _topicRepository.GetAll();
            foreach (var topic in topics)
            {
                topic.Body = await StorageApi.GetTopicBody(topic.Name);
                Cache[topic.Name] = topic;
            }

            return View(topics);
        }

        [HttpGet]
        [Route("topics/{name}")]
        public async Task<ActionResult> TopicByName(string name)
        {
            if (Cache.ContainsKey(name)) return View(Cache[name]);

            var topic = _topicRepository.GetByName(name);
            topic.Body = await StorageApi.GetTopicBody(topic.Name);
            Cache[topic.Name] = topic;
            return View(topic);
        }

        [Route("topics/New")]
        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        [Route("topics/Publish")]
        public async Task<ActionResult> Publish(Topic topic)
        {
            topic.Creator = AuthController.LoggedInUser;
            topic.FilePath = "/";
            _topicRepository.Create(topic);
            await StorageApi.PostTopicBody(topic);
            Cache[topic.Name] = topic;
            return RedirectToAction(topic.Name, "Topics");
        }

        [Route("topics/UpVote")]
        public IActionResult UpVote(string topicName)
        {
            Cache[topicName].UpVotes++;
            _topicRepository.AddVote(new Vote
            {
                Type = "Up",
                Topic = Cache[topicName],
                Voter = AuthController.LoggedInUser
            });
            return RedirectToAction(topicName, "Topics");
        }

        [Route("topics/DownVote")]
        public IActionResult DownVote(string topicName)
        {
            Cache[topicName].DownVotes++;
            _topicRepository.AddVote(new Vote
            {
                Type = "Down",
                Topic = Cache[topicName],
                Voter = AuthController.LoggedInUser
            });
            return RedirectToAction(topicName, "Topics");
        }

    }
}