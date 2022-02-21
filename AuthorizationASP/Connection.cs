using System.Data.SqlClient;

namespace AuthorizationASP
{
    public class Connection
    {
        SqlConnection connection;
        public Connection()
        {
            connection = new SqlConnection("Data Source=server1;Initial Catalog=UsersData;User Id=student;");
            connection.Open();
        }

    }
}
