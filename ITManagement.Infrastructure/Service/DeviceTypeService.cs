using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ITManagement.Core.Model;
using ITManagement.Core.Repository;
using ITManagement.Infrastructure.Commands.DeviceType;
using ITManagement.Infrastructure.DTO;
using ITManagement.Infrastructure.Extensions;

namespace ITManagement.Infrastructure.Service
{
    public class DeviceTypeService : IDeviceTypeService
    {
        private readonly IDeviceTypeRepository _deviceTypeRepository;
        private readonly IMapper _mapper;

        public DeviceTypeService(IDeviceTypeRepository deviceTypeRepository, IMapper mapper)
        {
            _deviceTypeRepository = deviceTypeRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(CreateDeviceType createDeviceType)
        {
            if (createDeviceType.Name.Empty())
                return;

            var deviceType = await _deviceTypeRepository.GetAsync(createDeviceType.Name.ToUpper());

            if (deviceType != null)
                return;

            var newDeviceType = new DeviceType(createDeviceType.Name);

            await _deviceTypeRepository.AddAsync(newDeviceType);
        }

        public async Task<DeviceTypeDTO> GetAsync(string name)
        {
            var deviceType = await _deviceTypeRepository.GetAsync(name.ToUpper());
            return _mapper.Map<DeviceType,DeviceTypeDTO>(deviceType);
        }

        public async Task<IEnumerable<DeviceTypeDTO>> GetAsync()
        {
            var deviceTypes = await _deviceTypeRepository.GetAsync();
            return _mapper.Map<IEnumerable<DeviceType>,IEnumerable<DeviceTypeDTO>>(deviceTypes);
        }
    }
}
