using System;
namespace ITManagement.Infrastructure.Commands.Device
{
    public class ChangeDeviceSerialNumber
    {
        public string InternalNumber { get; set; }
        public string NewSerialNumber { get; set; }
    }
}
