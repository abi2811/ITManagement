using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ITManagement.Core.Model;
using ITManagement.Core.Repository;
using ITManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ITManagement.Infrastructure.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly DataContext _context;

        public ClientRepository(DataContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Client client)
        {
            await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();
        }

        public async Task<Client> GetAsync(string email)
        {
            var client = await _context.Clients
                    .Include(c => c.Departament)
                    .FirstOrDefaultAsync(x => x.Email == email);

            return client;
        }

        public async Task<IEnumerable<Client>> GetAsync()
        {
            var clients = await _context.Clients
                    .Include(d => d.Departament)
                    .ToListAsync();
            return clients;
        }
    }
}
