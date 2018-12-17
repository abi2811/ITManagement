using System;
namespace ITManagement.Infrastructure.Commands.User
{
    public class ChangeUserPassword
    {
        public string Email { get; set; }
        public string NewPassword { get; set; }
    }
}
