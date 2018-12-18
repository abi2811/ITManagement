using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITManagement.Core.Model;
using ITManagement.Core.Repository;
using ITManagement.Infrastructure.Data;
using ITManagement.Infrastructure.DTO;
using Microsoft.EntityFrameworkCore;

namespace ITManagement.Infrastructure.Repository
{
    public class DeviceEventRepository : IDeviceEventRepository
    {
        private readonly DataContext _context;

        public DeviceEventRepository(DataContext context)
        {
            _context = context;
        }
        public async Task AddAsync(DeviceEvent deviceEvent)
        {
            await _context.DeviceEvents.AddAsync(deviceEvent);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DeviceEvent>> GetAsync(Device device)
        {
            var deviceEvents = await _context.DeviceEvents
                                        .Where(x => x.Device == device)
                                        .Include(d => d.Device)
                                        .ToListAsync();
            return deviceEvents;
        }

        public async Task<IEnumerable<DeviceEvent>> GetAsync()
        {
            var deviceEvents = await _context.DeviceEvents
                                        .Include(d => d.Device)
                                        .ToListAsync();

            return deviceEvents;
        }
    }
}