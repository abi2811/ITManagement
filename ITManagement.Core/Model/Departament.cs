using System;

namespace ITManagement.Core.Model
{
    public class Departament
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }

        public Departament(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}