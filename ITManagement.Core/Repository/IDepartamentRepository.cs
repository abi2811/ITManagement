using System.Collections.Generic;
using System.Threading.Tasks;
using ITManagement.Api.Repository;
using ITManagement.Core.Model;

namespace ITManagement.Core.Repository
{
    public interface IDepartamentRepository
    {
        Task<Departament> GetAsync(string name);
        Task<IEnumerable<Departament>> GetAsync();
        Task AddAsync(Departament departament);
    }
}
