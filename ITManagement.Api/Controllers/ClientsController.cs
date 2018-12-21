using System.Threading.Tasks;
using ITManagement.Core.Model;
using ITManagement.Infrastructure.Commands.Client;
using ITManagement.Infrastructure.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ClientsController : Controller
    {
        private readonly IClientService _service;

        public ClientsController(IClientService service)
        {
            _service = service;
        }
        /// <summary>
        /// Get all clients.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok(await _service.GetAsync());

        [HttpGet("{email}")]
        public async Task<IActionResult> Get(string email)
            => Ok(await _service.GetAsync(email));

        [HttpPut]
        public async Task<IActionResult> Put([FromBody]CreateClient request)
        {
            await _service.AddAsync(request);
            return Created($"clients/{request.Email}", null);
        }
    }
}
