using System;
namespace ITManagement.Core.Model
{
    public class DeviceType
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public DateTime CreatedAt { get; protected set; }

        protected DeviceType() {}

        public DeviceType(string name)
        {
            Id = Guid.NewGuid();
            Name = name.ToUpper();
            CreatedAt = DateTime.UtcNow;
        }
    }
}
