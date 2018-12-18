using System;

namespace ITManagement.Infrastructure.DTO
{
    public class DeviceDTO
    {
        public string Name { get; set; }
        public string InternalNumber { get; set; }
        public string SerialNumber { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string ClientEmail { get; set; }
        public string DeviceTypeName { get; set; }
    }
}