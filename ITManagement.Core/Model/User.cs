using System;

namespace ITManagement.Core.Model
{
    public class User
    {
        public Guid Id { get; protected set; }
        public string Username { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }
        public string Salt { get; protected set; }
        public string Hash { get; protected set; }

        protected User() {}

        public User(string username, string email, string password, string salt, string hash)
        {
            Id = Guid.NewGuid();
            Username = username;
            Email = email;
            Password = password;
            Salt = salt;
            Hash = hash;
        }
    }
}