using System;
using System.Collections.Generic;

namespace ITManagement.Core.Model
{
    public class Device
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public string InternalNumber { get; protected set; }
        public string SerialNumber { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }
        public Client Client { get; protected set; }
        public ISet<DeviceEvent> DeviceEvents { get; protected set; }

        protected Device(){}

        public Device(string name, string internalNumber, string serialNumber)
        {
            Id = Guid.NewGuid();
            Name = name;
            InternalNumber = internalNumber;
            SerialNumber = serialNumber;
            CreatedAt = DateTime.UtcNow;
            DeviceEvents = new HashSet<DeviceEvent>();
            DeviceEvents.Add(new DeviceEvent(this,$"Created device."));
        }
    }
}