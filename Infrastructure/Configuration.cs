using Oracle.ManagedDataAccess.Client;

namespace Infrastructure
{
    public static class Configuration
    {
        private const string UserName = "zerobased";
        private const string Password = "zerobased";

        private static readonly string ConnectionString = 
            $@"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))
            (CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = ORCLCDB.localdomain))); User Id={UserName}; Password={Password};";

        public static readonly OracleConnection Connection = new OracleConnection(ConnectionString);

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
