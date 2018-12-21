using System;
using System.Threading.Tasks;
using ITManagement.Infrastructure.DTO;

namespace ITManagement.Infrastructure.Service
{
    public interface IJwtHandler
    {
         JwtDTO CreateToken(Guid userId);
    }
}