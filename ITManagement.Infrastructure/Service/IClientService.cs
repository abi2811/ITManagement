using System.Collections.Generic;
using System.Threading.Tasks;
using ITManagement.Core.Model;
using ITManagement.Infrastructure.Commands.Client;
using ITManagement.Infrastructure.DTO;

namespace ITManagement.Infrastructure.Service
{
    public interface IClientService
    {
        Task<ClientDTO> GetAsync(string email);
        Task<IEnumerable<ClientDTO>> GetAsync();
        Task AddAsync(CreateClient createClient);
    }
}
