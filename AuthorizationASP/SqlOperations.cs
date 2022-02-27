using System;
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
            using(command = new SqlCommand($"SELECT * FROM [User] WHERE [Login] = '{login}'", connection))
            {
                using(SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                        return true;
                }
            }
            return false;
        }
        public bool isEmailExist(string email)
        {
            using (command = new SqlCommand($"SELECT * FROM [User] WHERE [Email] = '{email}'", connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                        return true;
                }
            }
            return false;
        }

        public bool AddUser(string login, string email, string password, DateTime birthday)
        {
            try
            {
                using (command = new SqlCommand($"INSERT INTO [User] VALUES('{login}', '{birthday.ToString("yyyy'-'MM'-'dd")}', " +
                $"'{password}', '{email}', '{DateTime.Now.ToString("yyyy'-'MM'-'dd")}', 1)", connection))
                {
                    command.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }
        public bool AddAdmin(string login, string email, string password, DateTime birthday)
        {
            try
            {
                using (command = new SqlCommand($"INSERT INTO [User] VALUES('{login}', '{birthday.ToString("yyyy'-'MM'-'dd")}', " +
                $"'{password}', '{email}', '{DateTime.Now.ToString("yyyy'-'MM'-'dd")}', 2)", connection))
                {
                    command.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
