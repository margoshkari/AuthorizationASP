using System.Data.SqlClient;

namespace AuthorizationASP
{
    public class SqlOperations
    {
        SqlConnection connection;
        SqlCommand command;
        public SqlOperations()
        {
            connection = Connection.GetConnection();
            command = new SqlCommand();
        }
        public bool isLoginExist(string login)
        {
            using(command = new SqlCommand($"SELECT * FROM [User] WHERE [Login] = {login}", connection))
            {
                SqlDataReader reader = command.ExecuteReader();
                if(reader.Read())
                    return true;
            }
            return false;
        }
        public bool isEmailExist(string email)
        {
            using (command = new SqlCommand($"SELECT * FROM [User] WHERE [Email] = {email}", connection))
            {
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                    return true;
            }
            return false;
        }
    }
}
