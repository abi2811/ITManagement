using System;
using System.Threading.Tasks;
using ITManagement.Infrastructure.Commands.DeviceEvent;
using ITManagement.Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;

namespace ITManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceEventsController : Controller
    {
        private readonly IDeviceEventService _service;

        public DeviceEventsController(IDeviceEventService service)
        {
            _service = service;
        }

        [HttpGet("{internalNumber}")]
        public async Task<IActionResult> Get(string internalNumber)
            => Ok(await _service.GetAsync(internalNumber));

        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok(await _service.GetAsync());

    }
}