using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ITManagement.Core.Model;
using ITManagement.Core.Repository;
using ITManagement.Infrastructure.Commands.Departament;

namespace ITManagement.Infrastructure.Service
{
    public class DepartamentService : IDepartamentService
    {
        private readonly IDepartamentRepository _repository;

        public DepartamentService(IDepartamentRepository repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(CreateDepartament createDepartament)
        {
            var departamentName = createDepartament.Name.ToUpper();

            if (string.IsNullOrWhiteSpace(departamentName))
                return;

            if (await _repository.GetAsync(departamentName) != null)
                throw new Exception($"Departament {departamentName} is already exists.");

            var departament = new Departament(departamentName);
            await _repository.AddAsync(departament);
        }

        public async Task<Departament> GetAsync(string name)
        {
            var departament = await _repository.GetAsync(name);
            return departament;
        }

        public async Task<IEnumerable<Departament>> GetAsync()
        {
            var departaments = await _repository.GetAsync();
            return departaments;
        }
    }
}
