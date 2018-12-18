using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ITManagement.Core.Model;
using ITManagement.Core.Repository;
using ITManagement.Infrastructure.Commands.DeviceEvent;
using ITManagement.Infrastructure.DTO;

namespace ITManagement.Infrastructure.Service
{
    public class DeviceEventService : IDeviceEventService
    {
        private readonly IDeviceEventRepository _deviceEventRepository;
        private readonly IDeviceRepository _deviceRepository;
        private readonly IMapper _mapper;

        public DeviceEventService(IDeviceEventRepository deviceEventRepository, IDeviceRepository deviceRepository, IMapper mapper)
        {
            _deviceEventRepository = deviceEventRepository;
            _deviceRepository = deviceRepository;
            _mapper = mapper;
        }
        public async Task AddAsync(CreateDeviceEvent createDeviceEvent)
        {
            if(string.IsNullOrWhiteSpace(createDeviceEvent.EventText))
                return;
            if(string.IsNullOrWhiteSpace(createDeviceEvent.InternalNumber))
                return;

            var device = await _deviceRepository.GetAsync(createDeviceEvent.InternalNumber.ToUpper());

            if(device == null)
                return;

            var deviceEvent = new DeviceEvent(device, createDeviceEvent.EventText);
            await _deviceEventRepository.AddAsync(deviceEvent);
        }

        public async Task<IEnumerable<DeviceEventDTO>> GetAsync(string internalNumber)
        {
            if(string.IsNullOrWhiteSpace(internalNumber))
                throw new ArgumentNullException();
            
            var device = await _deviceRepository.GetAsync(internalNumber.ToUpper());

            if(device == null)
                throw new Exception("Device does not exists.");

            var deviceEvents = await _deviceEventRepository.GetAsync(device);
            
            return _mapper.Map<IEnumerable<DeviceEvent>, IEnumerable<DeviceEventDTO>>(deviceEvents);
        }

        public async Task<IEnumerable<DeviceEventDTO>> GetAsync()
        {
            var deviceEvents = await _deviceEventRepository.GetAsync();
            
            return _mapper.Map<IEnumerable<DeviceEvent>, IEnumerable<DeviceEventDTO>>(deviceEvents);
        }
    }
}