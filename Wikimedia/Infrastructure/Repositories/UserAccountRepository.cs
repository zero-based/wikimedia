using Core.Models;
using Infrastructure.Interfaces;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class UserAccountRepository : IRepository<UserAccount>
    {
        public void Create(UserAccount userAccount)
        {
            var command = new OracleCommand
            {
                Connection = InfraConfig.Connection,
                CommandText = "SIGN_UP",
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.Add("Email", userAccount.Email);
            command.Parameters.Add("Username", userAccount.Username);
            command.Parameters.Add("FirstName", userAccount.FirstName);
            command.Parameters.Add("LastName", userAccount.LastName);
            command.Parameters.Add("JoinDate", DateTime.Now);
            command.Parameters.Add("Points", userAccount.Points);
            command.Parameters.Add("Password", userAccount.Password);

            command.ExecuteNonQuery();

        }

        public UserAccount Get(string userAccountEmail)
        {
            //var userAccount = new UserAccount();
            //var command = new OracleCommand
            //{
            //    Connection = InfraConfig.Connection,
            //    CommandText = "SELECT * FROM UserAccount WHERE Email =: Email"
            //};

            //command.Parameters.Add("Email", userAccountEmail);
            //using (var reader = command.ExecuteReader())
            //{
            //    while (reader.Read())
            //    {
            //        userAccount = new UserAccount
            //        {
            //            JoinDate = DateTime.Parse(reader["JoinDate"].ToString()),
            //            Points = int.Parse(reader["Points"].ToString()),
            //            FirstName = reader["FirstName"].ToString(),
            //            Password = reader["Password"].ToString(),
            //            LastName = reader["LastName"].ToString(),
            //            Username = reader["Username"].ToString(),
            //            Email = reader["Email"].ToString()
            //        };
            //    }
            //}

            //return userAccount;

            var userAccount = new UserAccount();
            var command = new OracleCommand
            {
                Connection = InfraConfig.Connection,
                CommandText = "SIGN_IN",
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.Add("User_Email", userAccountEmail);
            command.Parameters.Add("User_Username", OracleDbType.Varchar2, ParameterDirection.Output);
            command.Parameters.Add("User_FirstName", OracleDbType.Varchar2, ParameterDirection.Output);
            command.Parameters.Add("User_LastName", OracleDbType.Varchar2, ParameterDirection.Output);
            command.Parameters.Add("User_JoinDate", OracleDbType.Date, ParameterDirection.Output);
            command.Parameters.Add("User_Points", OracleDbType.Int64, ParameterDirection.Output);
            command.Parameters.Add("User_Password", OracleDbType.Varchar2, ParameterDirection.Output);

            command.ExecuteNonQuery();
            try
            {
                userAccount = new UserAccount
                {
                    Username = command.Parameters["User_Username"].Value.ToString(),
                    FirstName = command.Parameters["User_FirstName"].Value.ToString(),
                    LastName = command.Parameters["User_LastName"].Value.ToString(),
                    JoinDate = DateTime.Parse(command.Parameters["User_JoinDate"].Value.ToString()),
                    Points = int.Parse(command.Parameters["User_Points"].Value.ToString()),
                    Password = command.Parameters["User_Password"].Value.ToString(),
                };
            }
            catch
            {
                userAccount = null;
            }

            return userAccount;
        }

        public IEnumerable<UserAccount> GetAll()
        {
            var adapter = new OracleDataAdapter("SELECT * FROM UserAccount", InfraConfig.Connection);
            var ds = new DataSet();
            adapter.Fill(ds);

            return from DataRow row in ds.Tables[0].Rows
                   select new UserAccount
                   {
                       Email = row["Email"].ToString(),
                       Username = row["Username"].ToString(),
                       FirstName = row["FirstName"].ToString(),
                       LastName = row["LastName"].ToString(),
                       JoinDate = DateTime.Parse(row["JoinDate"].ToString()),
                       Points = int.Parse(row["Points"].ToString()),
                       Password = row["Password"].ToString(),
                   };
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

        public void AddPoints(string username)
        {
            var adapter = new OracleDataAdapter("SELECT * FROM UserAccount", InfraConfig.Connection);
            var ds = new DataSet();
            adapter.Fill(ds);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                if (row["Username"].ToString() == username)
                {
                    row["Points"] = Convert.ToInt64(row["Points"].ToString()) + 100;
                }
            }

            var builder = new OracleCommandBuilder(adapter);
            adapter.Update(ds);
        }
    }
}
