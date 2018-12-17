using System;
namespace ITManagement.Infrastructure.Commands.Client
{
    public class CreateClient : ICommand
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Departament { get; set; }
    }
}
