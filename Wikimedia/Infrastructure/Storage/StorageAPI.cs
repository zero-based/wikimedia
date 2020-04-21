using Core.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Storage
{
    public static class StorageApi
    {
        private const string TopicsEndpoint = "topics/";

        public static async Task<string> GetTopicBody(string topicName)
        {
            var route = InfraConfig.StorageBasePath + TopicsEndpoint + topicName;

            string body;
            using (var client = new HttpClient())
            {
                try
                {
                    body = await client.GetStringAsync(route);
                }
                catch (Exception)
                {
                    body = "Topic not Available now!";
                }
            }

            return body;
        }

        public static async Task PostTopicBody(Topic topic)
        {
            var route = InfraConfig.StorageBasePath + TopicsEndpoint + topic.Name;
            var topicJson = new
            {
                topic = new
                {
                    body = topic.Body
                }
            };

            var json = JsonConvert.SerializeObject(topicJson);
            using (var client = new HttpClient())
            {
                await client.PostAsync(route, new StringContent(json, Encoding.UTF8, "application/json"));
            }
        }
    }
}
