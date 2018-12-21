using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ITManagement.Api.Repository;
using ITManagement.Core.Model;
using ITManagement.Infrastructure.Commands.User;
using ITManagement.Infrastructure.DTO;
using ITManagement.Infrastructure.Extensions;
using Microsoft.AspNetCore.Identity;

namespace ITManagement.Infrastructure.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        private readonly IEncrypter _encrypter;
        private readonly IJwtHandler _handler;

        public UserService(IUserRepository repository, 
                            IMapper mapper, 
                            IEncrypter encrypter,
                            IJwtHandler handler)
        {
            _repository = repository;
            _mapper = mapper;
            _encrypter = encrypter;
            _handler = handler;
        }

        public async Task AddAsync(CreateUser createUser)
        {
            if (createUser.Username.Empty())
                return;
            if (createUser.Email.Empty())
                return;
            if (createUser.Password.Empty())
                return;
            if (await _repository.GetAsync(createUser.Email.ToUpper()) != null)
                throw new Exception($"User with email {createUser.Email.ToUpper()} " +
                                    "already exists.");

            var salt = _encrypter.GetSalt(createUser.Password);
            var passwordHashed = _encrypter.GetHash(createUser.Password, salt);

            var user = new User(createUser.Username.ToUpper(),
                                createUser.Email.ToUpper(), 
                                passwordHashed,
                                salt);

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
            if (changeUserEmail.Email.Empty())
                return;
            if (changeUserEmail.NewEmail.Empty())
                return;

            var user = await _repository.GetAsync(changeUserEmail.Email.ToUpper());

            if (user == null)
                return;

            user.SetEmail(changeUserEmail.NewEmail.ToUpper());
            await _repository.UpdateAsync(user);
        }

        public async Task ChangePasswordAsync(ChangeUserPassword changeUserPassword)
        {
            if (changeUserPassword.Email.Empty())
                return;
            if (changeUserPassword.NewPassword.Empty())
                return;

            var user = await _repository.GetAsync(changeUserPassword.Email.ToUpper());

            if (user == null)
                return;

            var oldPasswordHashed = _encrypter.GetHash(changeUserPassword.OldPassword, user.Salt);

            if(user.Password != oldPasswordHashed)
                throw new Exception("Invalid credentials.");

            var salt = _encrypter.GetSalt(changeUserPassword.NewPassword);
            var hash = _encrypter.GetHash(changeUserPassword.NewPassword, salt);

            user.SetPassword(hash, salt);
            await _repository.UpdateAsync(user);
        }

        public async Task<JwtDTO> Login(LoginUser loginUser)
        {
            if(loginUser.Email.Empty())
                throw new Exception("Invalid credentials.");
            if (loginUser.Password.Empty())
                throw new Exception("Invalid credentials.");

            var user = await _repository.GetAsync(loginUser.Email);

            if(user == null)
                throw new Exception("Invalid credentials.");

            if (user.Password == _encrypter.GetHash(loginUser.Password, user.Salt))
                return _handler.CreateToken(user.Id);
            throw new Exception("Invalid credentials.");
        }
    }
}