using System.Collections.Generic;
using System.Threading.Tasks;
using ITManagement.Core.Model;
using ITManagement.Core.Repository;
using ITManagement.Infrastructure.Commands.DeviceType;

namespace ITManagement.Infrastructure.Service
{
    public class DeviceTypeService : IDeviceTypeService
    {
        private readonly IDeviceTypeRepository _deviceTypeRepository;

        public DeviceTypeService(IDeviceTypeRepository deviceTypeRepository)
        {
            _deviceTypeRepository = deviceTypeRepository;
        }

        public async Task AddAsync(CreateDeviceType createDeviceType)
        {
            if (string.IsNullOrWhiteSpace(createDeviceType.Name))
                return;

            var deviceType = await _deviceTypeRepository.GetAsync(createDeviceType.Name.ToUpper());

            if (deviceType != null)
                return;

            var newDeviceType = new DeviceType(createDeviceType.Name);

            await _deviceTypeRepository.AddAsync(newDeviceType);
        }

        public async Task<DeviceType> GetAsync(string name)
        {
            var deviceType = await _deviceTypeRepository.GetAsync(name.ToUpper());
            return deviceType;
        }

        public async Task<IEnumerable<DeviceType>> GetAsync()
        {
            var deviceTypes = await _deviceTypeRepository.GetAsync();
            return deviceTypes;
        }
    }
}
