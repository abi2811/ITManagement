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
            if (string.IsNullOrWhiteSpace(createDepartament.Name))
                return;

            if (await _repository.GetAsync(createDepartament.Name.ToUpper()) != null)
                throw new Exception($"Departament is already exists.");

            var departament = new Departament(createDepartament.Name);
            await _repository.AddAsync(departament);
        }

        public async Task<Departament> GetAsync(string name)
        {
            var departament = await _repository.GetAsync(name.ToUpper());
            return departament;
        }

        public async Task<IEnumerable<Departament>> GetAsync()
        {
            var departaments = await _repository.GetAsync();
            return departaments;
        }
    }
}
