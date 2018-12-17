using System;
namespace ITManagement.Infrastructure.Commands.Device
{
    public class ChangeDeviceName
    {
        public string InternalNumber { get; set; }
        public string NewName { get; set; }
    }
}
