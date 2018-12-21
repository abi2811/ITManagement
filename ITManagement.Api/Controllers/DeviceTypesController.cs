using System;
using System.Threading.Tasks;
using ITManagement.Infrastructure.Commands.DeviceType;
using ITManagement.Infrastructure.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class DeviceTypesController : Controller
    {
        private readonly IDeviceTypeService _service;

        public DeviceTypesController(IDeviceTypeService service)
        {
            _service = service;
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
            => Ok(await _service.GetAsync(name));

        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok(await _service.GetAsync());

        [HttpPut]
        public async Task<IActionResult> Put([FromBody]CreateDeviceType request)
        {
            await _service.AddAsync(request);
            return Created($"devicetypes/{request.Name}", null);
        }
    }
}
