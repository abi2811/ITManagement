using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ITManagement.Api.Repository;
using ITManagement.Core.Model;
using ITManagement.Infrastructure.Commands.User;
using ITManagement.Infrastructure.DTO;

namespace ITManagement.Infrastructure.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AddAsync(CreateUser createUser)
        {
            if (string.IsNullOrWhiteSpace(createUser.Username))
                return;
            if (string.IsNullOrWhiteSpace(createUser.Email))
                return;
            if (string.IsNullOrWhiteSpace(createUser.Password))
                return;
            if (await _repository.GetAsync(createUser.Email.ToUpper()) != null)
                throw new Exception($"User with email {createUser.Email.ToUpper()} " +
                                    "already exists.");

            //TODO salt pass, hash pass
            var salt = "salt";
            var hash = "hash";

            var user = new User(createUser.Username.ToUpper(),
                                createUser.Email.ToUpper(), 
                                createUser.Password, 
                                salt, 
                                hash);

            await _repository.AddAsync(user);
        }

        public async Task<IEnumerable<UserDTO>> GetAsync()
        {
            var users = await _repository.GetAsync();
            return _mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(users);
        }

        public async Task<UserDTO> GetAsync(string email)
        {
            var user = await _repository.GetAsync(email);
            return _mapper.Map<User, UserDTO>(user);
        }

        public async Task ChangeEmailAsync(ChangeUserEmail changeUserEmail)
        {
            if (string.IsNullOrWhiteSpace(changeUserEmail.Email))
                return;
            if (string.IsNullOrWhiteSpace(changeUserEmail.NewEmail))
                return;

            var user = await _repository.GetAsync(changeUserEmail.Email.ToUpper());

            if (user == null)
                return;

            user.SetEmail(changeUserEmail.NewEmail.ToUpper());
            await _repository.UpdateAsync(user);
        }

        public async Task ChangePasswordAsync(ChangeUserPassword changeUserPassword)
        {
            if (string.IsNullOrWhiteSpace(changeUserPassword.Email))
                return;
            if (string.IsNullOrWhiteSpace(changeUserPassword.NewPassword))
                return;

            var user = await _repository.GetAsync(changeUserPassword.Email.ToUpper());

            if (user == null)
                return;

            //TODO - salt pass, hash pass
            var salt = "salt";
            var hash = "hash";

            user.SetPassword(changeUserPassword.NewPassword, salt, hash);
            await _repository.UpdateAsync(user);
        }
    }
}