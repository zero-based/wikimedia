using System;
using System.Collections.Generic;
using Core.Models;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class TopicsController : Controller
    {
        private static readonly Dictionary<string, Topic> Cache = new Dictionary<string, Topic>();
        private readonly TopicRepository _topicRepository = new TopicRepository();

        [Route("/")]
        [Route("topics/")]
        public ActionResult Index()
        {
            var topics = _topicRepository.GetAll();
            foreach (var topic in topics)
                Cache[topic.Name] = topic;

            return View(topics);
        }

        [HttpGet]
        [Route("topics/{name}")]
        public ActionResult TopicByName(string name)
        {
            if (Cache.ContainsKey(name)) return View(Cache[name]);

            var topic = _topicRepository.GetByName(name);
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
        public ActionResult Publish(Topic topic)
        {
            topic.Creator = AuthController.LoggedInUser;
            topic.FilePath = "/";
            _topicRepository.Create(topic);
            Cache[topic.Name] = topic;
            return RedirectToAction(topic.Name, "Topics");
        }
    }
}