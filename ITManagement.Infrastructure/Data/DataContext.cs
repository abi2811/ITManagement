
using ITManagement.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace ITManagement.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}
        public DbSet<User> Users { get; set; }

    }
}