using System.Collections.Generic;
using System.Threading.Tasks;
using ITManagement.Core.Model;
using ITManagement.Infrastructure.Commands.Client;
using ITManagement.Infrastructure.Commands.Device;
using ITManagement.Infrastructure.DTO;

namespace ITManagement.Infrastructure.Service
{
    public interface IDeviceService
    {
        Task<DeviceDTO> GetAsync(string internalNumber);
        Task<IEnumerable<DeviceDTO>> GetUserDevicesAsync(EmailClient emailClient);
        Task<IEnumerable<DeviceDTO>> GetAsync();
        Task CreateAsync(CreateDevice createDevice);
        Task ChangeClientAsync(ChangeDeviceClient changeClient);
        Task ChangeInternalNumberAsync(ChangeDeviceInternalNumber changeInternalNumber);
        Task ChangeSerialNumberAsync(ChangeDeviceSerialNumber changeSerialNumber);
        Task ChangeNameAsync(ChangeDeviceName changeName);
    }
}
