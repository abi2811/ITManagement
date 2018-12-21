using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ITManagement.Core.Model;
using ITManagement.Core.Repository;
using ITManagement.Infrastructure.Commands.Client;
using ITManagement.Infrastructure.Commands.Device;
using ITManagement.Infrastructure.Commands.DeviceEvent;
using ITManagement.Infrastructure.DTO;
using ITManagement.Infrastructure.Extensions;

namespace ITManagement.Infrastructure.Service
{
    public class DeviceService : IDeviceService
    {
        private readonly IDeviceRepository _deviceRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IDeviceTypeRepository _deviceTypeRepository;
        private readonly IDeviceEventRepository _deviceEventRepository;
        private readonly IMapper _mapper;

        public DeviceService(IDeviceRepository deviceRepository, 
                             IClientRepository clientRepository,
                             IDeviceTypeRepository deviceTypeRepository,
                             IDeviceEventRepository deviceEventRepository,
                             IMapper mapper)
        {
            _deviceRepository = deviceRepository;
            _clientRepository = clientRepository;
            _deviceTypeRepository = deviceTypeRepository;
            _deviceEventRepository = deviceEventRepository;
            _mapper = mapper;
        }

        public async Task CreateAsync(CreateDevice createDevice)
        {
            if (createDevice.InternalNumber.Empty())
                return;
            if (createDevice.Name.Empty())
                return;
            if (createDevice.SerialNumber.Empty())
                return;
            if (createDevice.DeviceType.Empty())
                return;

            var deviceType = await _deviceTypeRepository.GetAsync(createDevice.DeviceType.ToUpper());

            if (deviceType == null)
                throw new Exception("Device type does not exists.");

            var device = await _deviceRepository.GetAsync(createDevice.InternalNumber.ToUpper());

            if (device!= null)
                throw new Exception("Device with Internal number " +
                                    $"{createDevice.InternalNumber.ToUpper()} " +
                                    "already exists.");
            
            device = await _deviceRepository.GetDeviceAboutSerialNumber(createDevice.SerialNumber.ToUpper());

            if (device != null)
                throw new Exception("Device with Serial number " +
                                    $"{createDevice.SerialNumber.ToUpper()}" +
                                    "already exists.");

            device = new Device(createDevice.Name,
                                createDevice.InternalNumber,
                                createDevice.SerialNumber,
                                deviceType);

            await _deviceRepository.AddAsync(device);
            await _deviceEventRepository.AddAsync(new DeviceEvent(device, $"{DateTime.UtcNow} - Created device."));
        }

        public async Task<DeviceDTO> GetAsync(string internalNumber)
        {
            var device = await _deviceRepository.GetAsync(internalNumber.ToUpper());

            return _mapper.Map<Device, DeviceDTO>(device);
        }

        public async Task<IEnumerable<DeviceDTO>> GetAsync()
        {
            var devices = await _deviceRepository.GetAsync();

            return _mapper.Map<IEnumerable<Device>, IEnumerable<DeviceDTO>>(devices);
        }

        public async Task<IEnumerable<DeviceDTO>> GetUserDevicesAsync(EmailClient emailClient)
        {
            if (emailClient.Email.Empty())
            {
                throw new ArgumentNullException();
            }

            var client = await _clientRepository.GetAsync(emailClient.Email.ToUpper());

            if (client == null)
            {
                throw new Exception($"User does not exists.");
            }

            var devices = await _deviceRepository.GetDevicesAboutEmailClient(client);

            return _mapper.Map<IEnumerable<Device>, IEnumerable<DeviceDTO>>(devices);
        }

        public async Task ChangeClientAsync(ChangeDeviceClient changeClient)
        {
            if (changeClient.InternalNumber.Empty())
                return;
            if (changeClient.EmailClient.Empty())
                return;

            var client = await _clientRepository.GetAsync(changeClient.EmailClient.ToUpper());
            var device = await _deviceRepository.GetAsync(changeClient.InternalNumber.ToUpper());

            if (device == null)
                return;

            var oldClient = "null";

            if(device.Client != null)
                 oldClient = device.Client.Email;

            device.SetClient(client);

            await _deviceRepository.UpdateAsync(device);
            await _deviceEventRepository.AddAsync(new DeviceEvent(device, $"{DateTime.UtcNow} - Changed " +
                            $"device client from {oldClient} to {device.Client.Email}."));
        }

        public async Task ChangeInternalNumberAsync(ChangeDeviceInternalNumber changeInternalNumber)
        {
            if (changeInternalNumber.InternalNumber.Empty())
                return;

            if (changeInternalNumber.NewInternalNumber.Empty())
                return;

            var device = await _deviceRepository.GetAsync(changeInternalNumber.InternalNumber.ToUpper());

            if (device == null)
                return;

            var oldInternalNumber = device.InternalNumber;

            device.SetInternalNumber(changeInternalNumber.NewInternalNumber);

            await _deviceRepository.UpdateAsync(device);
            await _deviceEventRepository.AddAsync(new DeviceEvent(device, $"{DateTime.UtcNow} - Changed " +
                            $"device internal number from {oldInternalNumber} to {device.InternalNumber}."));
        }

        public async Task ChangeNameAsync(ChangeDeviceName changeName)
        {
            if (changeName.InternalNumber.Empty())
                return;
            if (changeName.NewName.Empty())
                return;

            var device = await _deviceRepository.GetAsync(changeName.InternalNumber.ToUpper());
            var oldName = device.Name;

            if (device == null)
                return;

            device.SetName(changeName.NewName);

            await _deviceRepository.UpdateAsync(device);
            await _deviceEventRepository.AddAsync(new DeviceEvent(device, $"{DateTime.UtcNow} - Changed " +
                            $"device internal number from {oldName} to {device.Name}."));
        }

        public async Task ChangeSerialNumberAsync(ChangeDeviceSerialNumber changeSerialNumber)
        {
            if (changeSerialNumber.InternalNumber.Empty())
                return;
            if (changeSerialNumber.NewSerialNumber.Empty())
                return;

            var device = await _deviceRepository.GetAsync(changeSerialNumber.InternalNumber.ToUpper());
            var oldSerialNumber = device.SerialNumber;

            if (device == null)
                return;

            device.SetSerialNumber(changeSerialNumber.NewSerialNumber);

            await _deviceRepository.UpdateAsync(device);
            await _deviceEventRepository.AddAsync(new DeviceEvent(device, $"{DateTime.UtcNow} - Changed " +
                            $"device internal number from {oldSerialNumber} to {device.SerialNumber}."));
        }

        public async Task ReturnDeviceFromClient(ReturnDeviceFromClient returnDeviceFromClient)
        {
            if(returnDeviceFromClient.InternalNumber.Empty())
                return;
            if(returnDeviceFromClient.ClientEmail.Empty())
                return;
            
            var device = await _deviceRepository.GetAsync(returnDeviceFromClient.InternalNumber.ToUpper());

            if (device == null)
                throw new Exception("Device does not exists.");
            
            var client = await _clientRepository.GetAsync(returnDeviceFromClient.ClientEmail.ToUpper());

            if (client == null)
                throw new Exception($"Client with email {returnDeviceFromClient.ClientEmail} does not exists.");
            
            if(device.Client != client)
                throw new Exception($"Client with email {client.Email} not use device {device.InternalNumber}.");

            device.SetClient();

            await _deviceEventRepository.AddAsync(new DeviceEvent(device, $"{DateTime.UtcNow} - {client.Email} returned device to company."));
            await _deviceRepository.UpdateAsync(device);
        }
    }
}
