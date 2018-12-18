using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITManagement.Core.Model;
using ITManagement.Core.Repository;
using ITManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ITManagement.Infrastructure.Repository
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly DataContext _context;

        public DeviceRepository(DataContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Device device)
        {
            await _context.Devices.AddAsync(device);
            await _context.SaveChangesAsync();
        }

        public async Task<Device> GetAsync(string internalnumber)
        {
            var device = await _context.Devices
                .Include(d => d.Client)
                .FirstOrDefaultAsync(x => x.InternalNumber == internalnumber.ToUpper());

            return device;
        }

        public async Task<IEnumerable<Device>> GetAsync()
        {
            var devices = await _context.Devices
                .Include(c => c.Client)
                .Include(t => t.DeviceType)
                .Include(e => e.DeviceEvents)
                .ToListAsync();

            return devices;
        }

        public async Task<Device> GetDeviceAboutSerialNumber(string serialnumber)
        {
            var device = await _context.Devices.FirstOrDefaultAsync(x =>
                x.SerialNumber == serialnumber);

            return device;
        }

        public async Task<IEnumerable<Device>> GetDevicesAboutEmailClient(Client client)
        {
            var devices = await _context.Devices.Where(x => x.Client == client).ToListAsync();

            return devices;
        }

        public async Task UpdateAsync(Device device)
        {
            _context.Devices.Update(device);
            await _context.SaveChangesAsync();
        }
    }
}
