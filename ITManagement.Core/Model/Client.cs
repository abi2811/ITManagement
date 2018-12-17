using System;

namespace ITManagement.Core.Model
{
    public class Client
    {
        public Guid Id { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string Email { get; protected set; }
        public Departament Departament { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }

        protected Client() {}

        public Client(string firstname, string lastname, string email, Departament departament)
        {
            Id = Guid.NewGuid();
            FirstName = firstname;
            LastName = lastname;
            Email = email;
            Departament = departament;
            CreatedAt = DateTime.UtcNow;
        }
    }
}