using System.Threading.Tasks;
using ITManagement.Core.Model;
using ITManagement.Infrastructure.Commands.Client;
using ITManagement.Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;

namespace ITManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : Controller
    {
        private readonly IClientService _service;

        public ClientsController(IClientService service)
        {
            _service = service;
        }

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
