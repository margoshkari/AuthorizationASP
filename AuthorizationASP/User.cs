using System;

namespace AuthorizationASP
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public DateTime Birthday { get; set; }
        public string Password { get; set; }

        public User(int id, string login, DateTime birthday, string password)
        {
            Id = id;
            Login = login;
            Birthday = birthday;
            Password = password;
        }
    }
}
