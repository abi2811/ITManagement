using System.Collections.Generic;
using System.Threading.Tasks;
using ITManagement.Core.Model;

namespace ITManagement.Api.Repository
{
    public interface IUserRepository
    {
        Task<User> GetAsync(string email);
        Task<IEnumerable<User>> GetAsync();
        Task AddAsync(User user);
        Task UpdateAsync(User user);
    }
}