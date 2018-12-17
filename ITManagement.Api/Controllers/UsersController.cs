using System.Threading.Tasks;
using ITManagement.Infrastructure.Commands.User;
using ITManagement.Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;

namespace ITManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUserService _service;

        public UsersController(IUserService service)
        {
            _service = service;
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> Get(string email)
            => Ok(await _service.GetAsync(email));


        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok(await _service.GetAsync());

        [HttpPut]
        public async Task<IActionResult> Put([FromBody]CreateUser request)
        {
            await _service.AddAsync(request);
            return Created($"users/{request.Email}", null);
        }
    }
}
