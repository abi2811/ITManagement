
using ITManagement.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace ITManagement.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}
        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<DeviceEvent> DeviceEvents { get; set; }
        public DbSet<Departament> Departaments { get; set; }
        public DbSet<DeviceType> DeviceTypes { get; set; }

    }
}