using System;
using System.Collections.Generic;

namespace ITManagement.Core.Model
{
    public class Device
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public string InternalNumber { get; protected set; }
        public string SerialNumber { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }
        public Client Client { get; protected set; }
        public DeviceType DeviceType { get; protected set; }
        public ISet<DeviceEvent> DeviceEvents { get; protected set; }

        protected Device(){}

        public Device(string name, string internalNumber, string serialNumber, DeviceType deviceType)
        {
            Id = Guid.NewGuid();
            Name = name.ToUpper();
            InternalNumber = internalNumber.ToUpper();
            SerialNumber = serialNumber.ToUpper();
            DeviceType = deviceType;
            CreatedAt = DateTime.UtcNow;
        }

        public void SetClient(Client client)
        {
            if (client == null)
                return;

            if (Client == client)
                throw new Exception("Device client already exists.");

            Client = client;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetInternalNumber(string newInternalNumber)
        {
            if (string.IsNullOrWhiteSpace(newInternalNumber))
                return;

            if (InternalNumber == newInternalNumber)
                throw new Exception("Device internal number already exists.");

            InternalNumber = newInternalNumber.ToUpper();
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetName(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
                return;

            if (Name == newName)
                throw new Exception("Device name already exists.");

            Name = newName.ToUpper();
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetSerialNumber(string newSerialNumber)
        {
            if (string.IsNullOrWhiteSpace(newSerialNumber))
                return;

            if (SerialNumber == newSerialNumber)
                throw new Exception("Device serial number already exists.");

            SerialNumber = newSerialNumber.ToUpper();
            UpdatedAt = DateTime.UtcNow;
        }
    }
}