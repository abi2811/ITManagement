using System.Collections.Generic;
using System.Threading.Tasks;
using ITManagement.Core.Model;
using ITManagement.Infrastructure.Commands.Departament;

namespace ITManagement.Infrastructure.Service
{
    public interface IDepartamentService
    {
        Task<Departament> GetAsync(string name);
        Task<IEnumerable<Departament>> GetAsync();
        Task AddAsync(CreateDepartament createDepartament);
    }
}
