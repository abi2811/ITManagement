using System.Collections.Generic;
using System.Threading.Tasks;
using ITManagement.Core.Model;
using ITManagement.Infrastructure.Commands.Client;

namespace ITManagement.Infrastructure.Service
{
    public interface IClientService
    {
        Task<Client> GetAsync(string email);
        Task<IEnumerable<Client>> GetAsync();
        Task AddAsync(CreateClient createClient);
    }
}
