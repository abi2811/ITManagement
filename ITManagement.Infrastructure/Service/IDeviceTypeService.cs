using System.Collections.Generic;
using System.Threading.Tasks;
using ITManagement.Core.Model;
using ITManagement.Infrastructure.Commands.DeviceType;
using ITManagement.Infrastructure.DTO;

namespace ITManagement.Infrastructure.Service
{
    public interface IDeviceTypeService
    {
        Task<DeviceTypeDTO> GetAsync(string name);
        Task<IEnumerable<DeviceTypeDTO>> GetAsync();
        Task AddAsync(CreateDeviceType createDeviceType);
    }
}
