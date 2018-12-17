using System;
namespace ITManagement.Infrastructure.Commands.Device
{
    public class CreateDevice : ICommand
    {
        public string Name { get; set; }
        public string InternalNumber { get; set; }
        public string SerialNumber { get; set; }
        public string DeviceType { get; set; }
    }
}
