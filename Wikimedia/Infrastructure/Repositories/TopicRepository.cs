using Core.Models;
using Infrastructure.Interfaces;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;

namespace Infrastructure.Repositories
{
    public class TopicRepository : IRepository<Topic>
    {
        public void Create(Topic topic)
        {
            var command = new OracleCommand
            {
                Connection = InfraConfig.Connection,
                CommandText = @"INSERT INTO Topic VALUES (:Name, :FilePath, :CreatorUsername)"
            };

            command.Parameters.Add("Name", topic.Name);
            command.Parameters.Add("FilePath", topic.FilePath);
            command.Parameters.Add("CreatorUsername", topic.Creator.Username);

            command.ExecuteNonQuery();
        }

        public Topic Get(string id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Topic> GetAll()
        {
            var topics = new List<Topic>();
            var command = new OracleCommand
            {
                Connection = InfraConfig.Connection,
                CommandText = "SELECT Name FROM Topic"
            };

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    topics.Add(GetByName(reader["Name"].ToString()));
                }
            }

            return topics;
        }

        public Topic GetByName(string name)
        {
            var topic = new Topic();
            var command = new OracleCommand
            {
                Connection = InfraConfig.Connection,
                CommandText = @"SELECT * FROM Topic t LEFT OUTER JOIN UserAccount u ON t.CreatorUsername = u.Username WHERE Name =: Name"
            };

            command.Parameters.Add("Name", name);
            using (var reader = command.ExecuteReader())
            {
                reader.Read();
                topic = new Topic
                {
                    Name = reader["Name"].ToString(),
                    FilePath = reader["FilePath"].ToString(),
                    Creator = new UserAccount
                    {
                        JoinDate = DateTime.Parse(reader["JoinDate"].ToString()),
                        Points = int.Parse(reader["Points"].ToString()),
                        FirstName = reader["FirstName"].ToString(),
                        Password = reader["Password"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Username = reader["CreatorUsername"].ToString(),
                        Email = reader["Email"].ToString()
                    }
                };
            }

            command = new OracleCommand
            {
                Connection = InfraConfig.Connection,
                CommandText = @"SELECT Count(*) FROM Vote WHERE Type = 'Up' AND TopicName =: TopicName"
            };
            command.Parameters.Add("TopicName", name);

            using (var reader = command.ExecuteReader())
            {
                reader.Read();
                topic.UpVotes = int.Parse(reader[0].ToString());
            }

            command = new OracleCommand
            {
                Connection = InfraConfig.Connection,
                CommandText = @"SELECT Count(*) FROM Vote WHERE Type = 'Down' AND TopicName =: TopicName"
            };
            command.Parameters.Add("TopicName", name);

            using (var reader = command.ExecuteReader())
            {
                reader.Read();
                topic.DownVotes = int.Parse(reader[0].ToString());
            }

            return topic;

        }

        public void Update(string id)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}
