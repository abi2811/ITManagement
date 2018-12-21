using System.Collections.Generic;
using System.Threading.Tasks;
using ITManagement.Infrastructure.Commands.User;
using ITManagement.Infrastructure.DTO;

namespace ITManagement.Infrastructure.Service
{
    public interface IUserService
    {
        Task<UserDTO> GetAsync(string email);
        Task<IEnumerable<UserDTO>> GetAsync();
        Task AddAsync(CreateUser createUser);
        Task ChangeEmailAsync(ChangeUserEmail changeUserEmail);
        Task ChangePasswordAsync(ChangeUserPassword changeUserPassword);
        Task<JwtDTO> Login(LoginUser loginUser);
    }
}