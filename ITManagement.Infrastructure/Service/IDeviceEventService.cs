using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ITManagement.Core.Model;
using ITManagement.Infrastructure.Commands.DeviceEvent;
using ITManagement.Infrastructure.DTO;

namespace ITManagement.Infrastructure.Service
{
    public interface IDeviceEventService
    {
        Task<IEnumerable<DeviceEventDTO>> GetAsync(string internalNumber);
        Task<IEnumerable<DeviceEventDTO>> GetAsync();
        Task AddAsync(CreateDeviceEvent createDeviceEvent);
    }
}