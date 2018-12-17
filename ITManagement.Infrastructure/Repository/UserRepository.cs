using System.Collections.Generic;
using System.Threading.Tasks;
using ITManagement.Api.Repository;
using ITManagement.Core.Model;
using ITManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ITManagement.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAsync()
        {
            var users = await _context.Users.ToListAsync();

            return users;
        }

        public async Task<User> GetAsync(string email)
        {
            var user = await _context.Users
                 .FirstOrDefaultAsync(x => x.Email == email);

            return user;
        }

        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}