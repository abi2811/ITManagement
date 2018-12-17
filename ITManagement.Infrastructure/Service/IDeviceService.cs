using System.Collections.Generic;
using System.Threading.Tasks;
using ITManagement.Core.Model;
using ITManagement.Infrastructure.Commands.Client;
using ITManagement.Infrastructure.Commands.Device;

namespace ITManagement.Infrastructure.Service
{
    public interface IDeviceService
    {
        Task<Device> GetAsync(string internalNumber);
        Task<IEnumerable<Device>> GetUserDevicesAsync(EmailClient emailClient);
        Task<IEnumerable<Device>> GetAsync();
        Task CreateAsync(CreateDevice createDevice);
        Task ChangeClientAsync(ChangeDeviceClient changeClient);
        Task ChangeInternalNumberAsync(ChangeDeviceInternalNumber changeInternalNumber);
        Task ChangeSerialNumberAsync(ChangeDeviceSerialNumber changeSerialNumber);
        Task ChangeNameAsync(ChangeDeviceName changeName);
    }
}
