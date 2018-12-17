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
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }

        protected User() {}

        public User(string username, string email, string password, string salt, string hash)
        {
            Id = Guid.NewGuid();
            Username = username;
            Email = email;
            Password = password;
            Salt = salt;
            Hash = hash;
            CreatedAt = DateTime.UtcNow;
        }

        public void SetEmail(string newEmail)
        {
            if (string.IsNullOrWhiteSpace(newEmail))
                return;

            if (Email == newEmail)
                throw new Exception("User email already exists.");

            Email = newEmail;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetPassword(string newPassword, string newSalt, string newHash)
        {
            if (string.IsNullOrWhiteSpace(newPassword))
                return;
            if (string.IsNullOrWhiteSpace(newSalt))
                return;
            if (string.IsNullOrWhiteSpace(newHash))
                return;

            if (Password == newPassword)
                throw new Exception("User password already exists.");

            if (newPassword.Length < 4 || newPassword.Length > 30)
                throw new Exception("User password must be lenght 4-30 characters.");

            Password = newPassword;
            Salt = newSalt;
            Hash = newHash;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}