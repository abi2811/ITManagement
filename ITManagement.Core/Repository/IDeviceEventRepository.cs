using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ITManagement.Core.Model;

namespace ITManagement.Core.Repository
{
    public interface IDeviceEventRepository
    {
         Task<IEnumerable<DeviceEvent>> GetAsync(Device device);
         Task<IEnumerable<DeviceEvent>> GetAsync();
         Task AddAsync(DeviceEvent deviceEvent);
    }
}