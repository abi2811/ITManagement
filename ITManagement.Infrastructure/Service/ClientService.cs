using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ITManagement.Core.Model;
using ITManagement.Core.Repository;
using ITManagement.Infrastructure.Commands.Client;

namespace ITManagement.Infrastructure.Service
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IDepartamentRepository _departamentRepository;

        public ClientService(IClientRepository clientRepository, IDepartamentRepository departamentRepository)
        {
            _clientRepository = clientRepository;
            _departamentRepository = departamentRepository;
        }

        public async Task AddAsync(CreateClient createClient)
        {
            if (string.IsNullOrWhiteSpace(createClient.Firstname))
                return;

            if (string.IsNullOrWhiteSpace(createClient.Lastname))
                return;

            if (string.IsNullOrWhiteSpace(createClient.Email))
                return;

            if (string.IsNullOrWhiteSpace(createClient.Departament))
                return;

            var departament = await _departamentRepository.GetAsync(createClient.Departament.ToUpper());

            if (departament == null)
                throw new Exception($"Departament {createClient.Departament} does not exists.");

            if (await _clientRepository.GetAsync(createClient.Email.ToUpper()) != null)
                throw new Exception($"Client email {createClient.Email} is already exists.");

            var client = new Client(createClient.Firstname, 
                                    createClient.Lastname, 
                                    createClient.Email, 
                                    departament);

            await _clientRepository.AddAsync(client);
        }

        public async Task<Client> GetAsync(string email)
        {
            var client = await _clientRepository.GetAsync(email.ToUpper());
            return client;
        }

        public async Task<IEnumerable<Client>> GetAsync()
        {
            var clients = await _clientRepository.GetAsync();
            return clients;
        }
    }
}
