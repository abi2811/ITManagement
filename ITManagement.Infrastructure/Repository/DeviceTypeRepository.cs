using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ITManagement.Core.Model;
using ITManagement.Core.Repository;
using ITManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ITManagement.Infrastructure.Repository
{
    public class DeviceTypeRepository : IDeviceTypeRepository
    {
        private readonly DataContext _context;

        public DeviceTypeRepository(DataContext context)
        {
            _context = context;
        }

        public async Task AddAsync(DeviceType deviceType)
        {
            await _context.DeviceTypes.AddAsync(deviceType);
            await _context.SaveChangesAsync();
        }

        public async Task<DeviceType> GetAsync(string name)
        {
            var deviceType = await _context.DeviceTypes
                                           .FirstOrDefaultAsync(x => x.Name == name);
            return deviceType;
        }

        public async Task<IEnumerable<DeviceType>> GetAsync()
        {
            var deviceTypes = await _context.DeviceTypes.ToListAsync();
            return deviceTypes;
        }
    }
}
