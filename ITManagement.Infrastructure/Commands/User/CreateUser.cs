using System;
namespace ITManagement.Infrastructure.Commands.User
{
    public class CreateUser : ICommand
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
