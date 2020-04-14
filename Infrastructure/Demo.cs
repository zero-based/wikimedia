using Oracle.ManagedDataAccess.Client;
using System.Collections.Generic;
using System.Data;

namespace Infrastructure
{
    public class Demo : IRepository<string>
    {
        public void Create(string obj)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new System.NotImplementedException();
        }

        public string Get(string id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<string> GetAll()
        {
            var interests = new List<string>();
            var command = new OracleCommand
            {
                Connection = Configuration.Connection,
                CommandText = "SELECT * FROM interest",
                CommandType = CommandType.Text
            };

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    interests.Add(reader["Name"].ToString());
                }
            }

            return interests;
        }

        public void Update(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}
