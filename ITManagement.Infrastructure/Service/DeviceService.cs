using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ITManagement.Core.Model;
using ITManagement.Core.Repository;
using ITManagement.Infrastructure.Commands.Client;
using ITManagement.Infrastructure.Commands.Device;

namespace ITManagement.Infrastructure.Service
{
    public class DeviceService : IDeviceService
    {
        private readonly IDeviceRepository _deviceRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IDeviceTypeRepository _deviceTypeRepository;

        public DeviceService(IDeviceRepository deviceRepository, 
                             IClientRepository clientRepository,
                             IDeviceTypeRepository deviceTypeRepository)
        {
            _deviceRepository = deviceRepository;
            _clientRepository = clientRepository;
            _deviceTypeRepository = deviceTypeRepository;
        }

        public async Task CreateAsync(CreateDevice createDevice)
        {
            if (string.IsNullOrWhiteSpace(createDevice.InternalNumber))
                return;
            if (string.IsNullOrWhiteSpace(createDevice.Name))
                return;
            if (string.IsNullOrWhiteSpace(createDevice.SerialNumber))
                return;
            if (string.IsNullOrWhiteSpace(createDevice.DeviceType))
                return;

            var deviceType = await _deviceTypeRepository.GetAsync(createDevice.DeviceType.ToUpper());

            if (deviceType == null)
                throw new Exception("Device type does not exists.");

            if (_deviceRepository.GetAsync(createDevice.InternalNumber.ToUpper()) != null)
                throw new Exception("Device with Internal number " +
                                    $"{createDevice.InternalNumber.ToUpper()} " +
                                    "already exists.");

            if (_deviceRepository.GetDeviceAboutSerialNumber(createDevice.SerialNumber.ToUpper()) != null)
                throw new Exception("Device with Serial number " +
                                    $"{createDevice.SerialNumber.ToUpper()}" +
                                    "already exists.");

            var device = new Device(createDevice.Name.ToUpper(),
                                    createDevice.InternalNumber.ToUpper(), 
                                    createDevice.SerialNumber.ToUpper(),
                                    deviceType);

            await _deviceRepository.AddAsync(device);
        }

        public async Task<Device> GetAsync(string internalNumber)
        {
            var device = await _deviceRepository.GetAsync(internalNumber);

            return device;
        }

        public async Task<IEnumerable<Device>> GetAsync()
        {
            var devices = await _deviceRepository.GetAsync();

            return devices;
        }

        public async Task<IEnumerable<Device>> GetUserDevicesAsync(EmailClient emailClient)
        {
            if (string.IsNullOrWhiteSpace(emailClient.Email))
            {
                throw new ArgumentNullException();
            }

            var client = await _clientRepository.GetAsync(emailClient.Email.ToUpper());

            if (client == null)
            {
                throw new Exception($"User does not exists.");
            }

            var devices = await _deviceRepository.GetDevicesAboutEmailClient(client);

            return devices;
        }

        public async Task ChangeClientAsync(ChangeDeviceClient changeClient)
        {
            if (string.IsNullOrWhiteSpace(changeClient.InternalNumber))
                return;
            if (string.IsNullOrWhiteSpace(changeClient.EmailClient))
                return;

            var client = await _clientRepository.GetAsync(changeClient.EmailClient.ToUpper());
            var device = await GetAsync(changeClient.InternalNumber.ToUpper());

            if (device == null)
                return;

            device.SetClient(client);
            await _deviceRepository.UpdateAsync(device);
        }

        public async Task ChangeInternalNumberAsync(ChangeDeviceInternalNumber changeInternalNumber)
        {
            if (string.IsNullOrWhiteSpace(changeInternalNumber.InternalNumber))
                return;

            if (string.IsNullOrWhiteSpace(changeInternalNumber.NewInternalNumber))
                return;

            var device = await GetAsync(changeInternalNumber.InternalNumber.ToUpper());

            if (device == null)
                return;

            device.SetInternalNumber(changeInternalNumber.NewInternalNumber.ToUpper());

            await _deviceRepository.UpdateAsync(device);
        }

        public async Task ChangeNameAsync(ChangeDeviceName changeName)
        {
            if (string.IsNullOrWhiteSpace(changeName.InternalNumber))
                return;
            if (string.IsNullOrWhiteSpace(changeName.NewName))
                return;

            var device = await GetAsync(changeName.InternalNumber.ToUpper());

            if (device == null)
                return;

            device.SetName(changeName.NewName.ToUpper());
            await _deviceRepository.UpdateAsync(device);
        }

        public async Task ChangeSerialNumberAsync(ChangeDeviceSerialNumber changeSerialNumber)
        {
            if (string.IsNullOrWhiteSpace(changeSerialNumber.InternalNumber))
                return;
            if (string.IsNullOrWhiteSpace(changeSerialNumber.NewSerialNumber))
                return;

            var device = await GetAsync(changeSerialNumber.InternalNumber.ToUpper());

            if (device == null)
                return;

            device.SetSerialNumber(changeSerialNumber.NewSerialNumber.ToUpper());
            await _deviceRepository.UpdateAsync(device);
        }
    }
}
