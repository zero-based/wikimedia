using Oracle.ManagedDataAccess.Client;

namespace Infrastructure
{
    public static class InfraConfig
    {
        private static readonly OracleConnectionStringBuilder Builder = new OracleConnectionStringBuilder
        {
            UserID = "zerobased",
            Password = "zerobased",
            DataSource = "(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))"+
                         "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=ORCLCDB.localdomain)))"
        };

        public static readonly OracleConnection Connection = new OracleConnection(Builder.ConnectionString);

        public static void Up()
        {
            Connection.Open();
        }

        public static void Down()
        {
            Connection.Close();
        }
    }
}
