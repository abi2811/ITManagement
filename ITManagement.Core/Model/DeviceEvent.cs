using System;

namespace ITManagement.Core.Model
{
    public class DeviceEvent
    {
        public Guid Id { get; protected set; }
        public Device Device { get; protected set; }
        public string EventText { get; protected set; }
        public DateTime CreatedAt { get; protected set; }

        protected DeviceEvent(){}

        public DeviceEvent(Device device, string eventText)
        {
            Id = Guid.NewGuid();
            Device = device;
            EventText = eventText;
            CreatedAt = DateTime.UtcNow;
        }
    }
}