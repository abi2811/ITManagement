using System;
using System.Threading.Tasks;
using ITManagement.Core.Model;
using ITManagement.Infrastructure.Commands.Departament;
using ITManagement.Infrastructure.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class DepartamentsController : Controller
    {
        private readonly IDepartamentService _service;

        public DepartamentsController(IDepartamentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok(await _service.GetAsync());

        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
            => Ok(await _service.GetAsync(name));

        [HttpPut]
        public async Task<IActionResult> Put([FromBody]CreateDepartament request)
        {
            await _service.AddAsync(request);

            return Created($"/departaments/{request.Name}", null);
        }
    }
}
