using Core.Models;
using Infrastructure.Interfaces;
using Oracle.ManagedDataAccess.Client;
using System.Collections.Generic;
using System.Data;

namespace Infrastructure.Repositories
{
    public class Demo : IRepository<Interest>
    {
        public void Create(Interest obj)
        {
            throw new System.NotImplementedException();
        }

        public Interest Get(string id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Interest> GetAll()
        {
            var interests = new List<Interest>();
            var command = new OracleCommand
            {
                Connection = InfraConfig.Connection,
                CommandText = "SELECT * FROM interest",
                CommandType = CommandType.Text
            };

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    interests.Add(new Interest
                        {Id = int.Parse(reader["Id"].ToString()), Name = reader["Name"].ToString()});
                }
            }

            return interests;
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
