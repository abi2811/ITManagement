using System;
using ITManagement.Core.Model;

namespace ITManagement.Infrastructure.DTO
{
    public class DeviceEventDTO
    {
        public string DeviceInternalNumber { get; set; }
        public string EventText { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}