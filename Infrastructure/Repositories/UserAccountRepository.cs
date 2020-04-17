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
            command.Parameters.Add("Points", "0");
            command.Parameters.Add("Email", userAccount.Email);

            command.ExecuteNonQuery();

        }

        public UserAccount Get(string userAccountEmail)
        {
            UserAccount userAccount = new UserAccount();
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
