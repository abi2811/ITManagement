using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ITManagement.Api.Repository;
using ITManagement.Core.Model;

namespace ITManagement.Core.Repository
{
    public interface IDeviceTypeRepository
    {
        Task<DeviceType> GetAsync(string name);
        Task<IEnumerable<DeviceType>> GetAsync();
        Task AddAsync(DeviceType deviceType);
    }
}
