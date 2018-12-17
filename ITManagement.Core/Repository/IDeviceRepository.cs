using System.Collections.Generic;
using System.Threading.Tasks;
using ITManagement.Api.Repository;
using ITManagement.Core.Model;

namespace ITManagement.Core.Repository
{
    public interface IDeviceRepository
    {
        Task<Device> GetAsync(string internalnumber);
        Task<Device> GetDeviceAboutSerialNumber(string serialnumber);
        Task<IEnumerable<Device>> GetDevicesAboutEmailClient(Client client);
        Task<IEnumerable<Device>> GetAsync();
        Task AddAsync(Device device);
        Task UpdateAsync(Device device);
    }
}
