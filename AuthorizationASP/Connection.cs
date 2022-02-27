using System.Data.SqlClient;

namespace AuthorizationASP
{
    public class Connection
    {
        private static SqlConnection connection;
        private Connection() { }
        public static SqlConnection GetConnection()
        {
            if (connection == null)
            {
                connection = new SqlConnection("Data Source=SQL5102.site4now.net;Initial Catalog=db_a837fa_userdata;User Id=db_a837fa_userdata_admin;Password=qwerty123");
                connection.Open();
            }
            return connection;
        }
    }
}
