using System;
using System.Diagnostics;
using System.Threading;
using Oracle.ManagedDataAccess.Client;

namespace Infrastructure
{
    public static class InfraConfig
    {
        public const string StorageBasePath = "http://storage:8080/";

        private static readonly OracleConnectionStringBuilder Builder = new OracleConnectionStringBuilder
        {
            UserID = "zerobased",
            Password = "zerobased",
            DataSource = "(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=db)(PORT=1521))" +
                         "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=ORCLCDB.localdomain)))"
        };

        public static readonly OracleConnection Connection = new OracleConnection(Builder.ConnectionString);

        public static void Up()
        {
            Retry(Connection.Open, 5, "Connected!", "Failed to connect.", "INFRA");
        }

        public static void Down()
        {
            Connection.Close();
        }

        private static void Retry(Action action, int interval, string successMsg, string failureMsg, string category)
        {
            while (true)
            {
                try
                {
                    action();
                    Debug.WriteLine(successMsg, category);
                    break;
                }
                catch (Exception)
                {
                    Debug.WriteLine(failureMsg, category);
                    Thread.Sleep(TimeSpan.FromSeconds(interval));
                }
            }
        }

    }
}
