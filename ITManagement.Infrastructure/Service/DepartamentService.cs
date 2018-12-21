using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ITManagement.Core.Model;
using ITManagement.Core.Repository;
using ITManagement.Infrastructure.Commands.Departament;
using ITManagement.Infrastructure.DTO;
using ITManagement.Infrastructure.Extensions;

namespace ITManagement.Infrastructure.Service
{
    public class DepartamentService : IDepartamentService
    {
        private readonly IDepartamentRepository _repository;
        private readonly IMapper _mapper;

        public DepartamentService(IDepartamentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AddAsync(CreateDepartament createDepartament)
        {
            if (createDepartament.Name.Empty())
                return;

            if (await _repository.GetAsync(createDepartament.Name.ToUpper()) != null)
                throw new Exception($"Departament is already exists.");

            var departament = new Departament(createDepartament.Name);
            await _repository.AddAsync(departament);
        }

        public async Task<DepartamentDTO> GetAsync(string name)
        {
            var departament = await _repository.GetAsync(name.ToUpper());
            return _mapper.Map<Departament, DepartamentDTO>(departament);
        }

        public async Task<IEnumerable<DepartamentDTO>> GetAsync()
        {
            var departaments = await _repository.GetAsync();
            return _mapper.Map<IEnumerable<Departament>,IEnumerable<DepartamentDTO>>(departaments);
        }
    }
}
