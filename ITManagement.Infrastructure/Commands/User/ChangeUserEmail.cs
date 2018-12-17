using System;
namespace ITManagement.Infrastructure.Commands.User
{
    public class ChangeUserEmail
    {
        public string Email { get; set; }
        public string NewEmail { get; set; }
    }
}
