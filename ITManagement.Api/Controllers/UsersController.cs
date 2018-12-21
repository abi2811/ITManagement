using System.Threading.Tasks;
using ITManagement.Infrastructure.Commands.User;
using ITManagement.Infrastructure.DTO;
using ITManagement.Infrastructure.Service;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public async Task<IActionResult> Get(string email)
            => Ok(await _service.GetAsync(email));


        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get()
            => Ok(await _service.GetAsync());

        [HttpPut]
        public async Task<IActionResult> Put([FromBody]CreateUser request)
        {
            await _service.AddAsync(request);
            return Created($"users/{request.Email}", null);
        }

        [HttpPost("changepassword")]
        [Authorize]
        public async Task<IActionResult> Post([FromBody]ChangeUserPassword request)
        {
            await _service.ChangePasswordAsync(request);
            return NoContent();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Post([FromBody]LoginUser request)
        {
            var token = await _service.Login(request);
            return Ok(token);
        }
    }
}
