using System.Threading.Tasks;
using ITManagement.Core.Model;

namespace ITManagement.Infrastructure.Service
{
    public interface IUserService
    {
         Task<User> GetAsync(string email);
         Task AddAsync(User user);
    }
}