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
                connection = new SqlConnection("Data Source=server1;Initial Catalog=UsersData;User Id=student;");
                connection.Open();
            }
            return connection;
        }
        /*CREATE DATABASE [UsersData];
USE UsersData;

CREATE TABLE [UserCategory]
(
	[ID] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL
);

CREATE TABLE [User]
(
	[ID] INT PRIMARY KEY IDENTITY,
	[Login] VARCHAR(30) UNIQUE NOT NULL,
	[Birthday] DATE NOT NULL,
	[PassHash] VARCHAR(120) NOT NULL,
	[Email] VARCHAR(120) UNIQUE NOT NULL,
	[RegistrDate] DATE NOT NULL,
	[IdCategory] INT NOT NULL,
	FOREIGN KEY ([IdCategory]) REFERENCES [UserCategory]([ID])
);*/
    }
}
