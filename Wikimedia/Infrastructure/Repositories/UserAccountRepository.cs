using Core.Models;
using Infrastructure.Interfaces;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;

namespace Infrastructure.Repositories
{
    public class UserAccountRepository : IRepository<UserAccount>
    {
        public void Create(UserAccount userAccount)
        {
            var command = new OracleCommand
            {
                Connection = InfraConfig.Connection,
                CommandText = @"INSERT INTO UserAccount VALUES (:UserName,:FirstName,:LastName,:Password,:JoinDate,:Points,:Email)"
            };

            command.Parameters.Add("Username", userAccount.Username);
            command.Parameters.Add("FirstName", userAccount.FirstName);
            command.Parameters.Add("LastName", userAccount.LastName);
            command.Parameters.Add("Password", userAccount.Password);
            command.Parameters.Add("JoinDate", DateTime.Now);
            command.Parameters.Add("Points", userAccount.Points);
            command.Parameters.Add("Email", userAccount.Email);

            command.ExecuteNonQuery();

        }

        public UserAccount Get(string userAccountEmail)
        {
            var userAccount = new UserAccount();
            var command = new OracleCommand
            {
                Connection = InfraConfig.Connection,
                CommandText = "SELECT * FROM UserAccount WHERE Email =: Email"
            };

            command.Parameters.Add("Email", userAccountEmail);
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    userAccount = new UserAccount
                    {
                        JoinDate = DateTime.Parse(reader["JoinDate"].ToString()),
                        Points = int.Parse(reader["Points"].ToString()),
                        FirstName = reader["FirstName"].ToString(),
                        Password = reader["Password"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Username = reader["Username"].ToString(),
                        Email = reader["Email"].ToString()
                    };
                }
            }

            return userAccount;
        }

        public IEnumerable<UserAccount> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public void Update(UserAccount userAccount)
        {
            var command = new OracleCommand
            {
                Connection = InfraConfig.Connection,
                CommandText = @"Update UserAccount SET FirstName =: FirstName, LastName =: LastName, Email =: Email, Password =: Password WHERE Username =: Username"
            };
            
            command.Parameters.Add("FirstName", userAccount.FirstName);
            command.Parameters.Add("LastName", userAccount.LastName);
            command.Parameters.Add("Email", userAccount.Email);
            command.Parameters.Add("Password", userAccount.Password);
            command.Parameters.Add("Username", userAccount.Username);

            command.ExecuteNonQuery();
        }

        public void Update(string id)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new System.NotImplementedException();
        }

        public List<Interest> GetInterests(string username)
        {
            var userInterests = new List<Interest>();
            var command = new OracleCommand
            {
                Connection = InfraConfig.Connection,
                CommandText = "SELECT InterestId, Name FROM Interest i, UserInterest ui WHERE i.id = ui.InterestId AND ui.Username = :username"
            };
            command.Parameters.Add("username", username);

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    userInterests.Add(new Interest
                    {
                        Id = int.Parse(reader["InterestId"].ToString()),
                        Name = reader["Name"].ToString()
                    });
                }
            }

            return userInterests;
        }

        public void InsertUserInterest(int id, string username)
        {
            var command = new OracleCommand
            {
                Connection = InfraConfig.Connection,
                CommandText = "INSERT INTO UserInterest (Username, InterestId) values (:username, :id)"
            };
            command.Parameters.Add("username", username);
            command.Parameters.Add("id", id);
            command.ExecuteNonQuery();
        }

        public void DeleteUserInterests(string username)
        {
            var command = new OracleCommand
            {
                Connection = InfraConfig.Connection,
                CommandText = "DELETE FROM UserInterest WHERE Username = :username"
            };
            command.Parameters.Add("username", username);
            command.ExecuteNonQuery();
        }

        public void UpdateUserInterests(List<Interest> interests, string username)
        {
            DeleteUserInterests(username);

            foreach (var interest in interests)
            {
                InsertUserInterest(interest.Id, username);
            }
        }
    }
}
