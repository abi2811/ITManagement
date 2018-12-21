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
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }

        protected User() {}

        public User(string username, string email, string password, string salt)
        {
            Id = Guid.NewGuid();
            Username = username.ToUpper();
            Email = email.ToUpper();
            Password = password;
            Salt = salt;
            CreatedAt = DateTime.UtcNow;
        }

        public void SetEmail(string newEmail)
        {
            if (string.IsNullOrWhiteSpace(newEmail))
                return;

            if (Email == newEmail)
                throw new Exception("User email already exists.");

            Email = newEmail.ToUpper();
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetPassword(string newPassword, string newSalt)
        {
            if (string.IsNullOrWhiteSpace(newPassword))
                return;
            if (string.IsNullOrWhiteSpace(newSalt))
                return;

            if (Password == newPassword)
                throw new Exception("User password already exists.");
                
            Password = newPassword;
            Salt = newSalt;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}