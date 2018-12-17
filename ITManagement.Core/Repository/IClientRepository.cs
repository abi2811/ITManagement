using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ITManagement.Api.Repository;
using ITManagement.Core.Model;

namespace ITManagement.Core.Repository
{
	public interface IClientRepository
    {
        Task<Client> GetAsync(string email);
        Task<IEnumerable<Client>> GetAsync();
        Task AddAsync(Client client);
    }
}
