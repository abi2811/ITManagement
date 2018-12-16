using System;

namespace ITManagement.Core.Model
{
    public class Client
    {
        public Guid Id { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public Departament Departament { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }

        protected Client() {}

        public Client(string firstname, string lastname, Departament departament)
        {
            Id = Guid.NewGuid();
            FirstName = firstname;
            LastName = lastname;
            Departament = departament;
            CreatedAt = DateTime.UtcNow;
        }

    }
}