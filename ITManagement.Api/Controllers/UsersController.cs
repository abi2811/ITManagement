using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITManagement.Core.Model;
using ITManagement.Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;

namespace ITManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;

        public UsersController(IUserService service)
        {
            _service = service;
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> Get(string email)
        {
            var user = await _service.GetAsync(email);
            return Ok(user);
        }

        // GET api/values/5
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]User request)
        {
            await _service.AddAsync(request);
            return StatusCode(204);
        }
    }
}
