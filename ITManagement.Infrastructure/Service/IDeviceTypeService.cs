using System.Collections.Generic;
using System.Threading.Tasks;
using ITManagement.Core.Model;
using ITManagement.Infrastructure.Commands.DeviceType;

namespace ITManagement.Infrastructure.Service
{
    public interface IDeviceTypeService
    {
        Task<DeviceType> GetAsync(string name);
        Task<IEnumerable<DeviceType>> GetAsync();
        Task AddAsync(CreateDeviceType createDeviceType);
    }
}
