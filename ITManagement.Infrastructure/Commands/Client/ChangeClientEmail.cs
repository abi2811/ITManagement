using System;
namespace ITManagement.Infrastructure.Commands.Client
{
    public class ChangeClientEmail
    {
        public string Email { get; set; }
        public string NewEmail { get; set; }
    }
}
