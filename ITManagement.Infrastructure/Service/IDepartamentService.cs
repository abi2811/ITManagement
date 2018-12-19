using System.Collections.Generic;
using System.Threading.Tasks;
using ITManagement.Core.Model;
using ITManagement.Infrastructure.Commands.Departament;
using ITManagement.Infrastructure.DTO;

namespace ITManagement.Infrastructure.Service
{
    public interface IDepartamentService
    {
        Task<DepartamentDTO> GetAsync(string name);
        Task<IEnumerable<DepartamentDTO>> GetAsync();
        Task AddAsync(CreateDepartament createDepartament);
    }
}
