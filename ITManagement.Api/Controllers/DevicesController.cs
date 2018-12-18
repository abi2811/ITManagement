using System;
using System.Threading.Tasks;
using ITManagement.Infrastructure.Commands.Client;
using ITManagement.Infrastructure.Commands.Device;
using ITManagement.Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;

namespace ITManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevicesController : Controller
    {
        private readonly IDeviceService _service;

        public DevicesController(IDeviceService service)
        {
            _service = service;
        }

        [HttpGet("{internalNumber}")]
        public async Task<IActionResult> Get(string internalNumber)
            => Ok(await _service.GetAsync(internalNumber));

        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok(await _service.GetAsync());

        [HttpGet("client")]
        public async Task<IActionResult> Get([FromBody]EmailClient request)
            => Ok(await _service.GetUserDevicesAsync(request));

        [HttpPut]
        public async Task<IActionResult> Put([FromBody]CreateDevice request)
        {
            await _service.CreateAsync(request);

            return Created($"devices/{request.InternalNumber}", null);
        }

        [HttpPost("changeclient")]
        public async Task<IActionResult> Post([FromBody]ChangeDeviceClient request)
        {
            await _service.ChangeClientAsync(request);

            return NoContent();
        }

        [HttpPost("changeinternalnumber")]
        public async Task<IActionResult> Post([FromBody]ChangeDeviceInternalNumber request)
        {
            await _service.ChangeInternalNumberAsync(request);

            return NoContent();
        }

        [HttpPost("changeserialnumber")]
        public async Task<IActionResult> Post([FromBody]ChangeDeviceSerialNumber request)
        {
            await _service.ChangeSerialNumberAsync(request);

            return NoContent();
        }

        [HttpPost("changename")]
        public async Task<IActionResult> Post([FromBody]ChangeDeviceName request)
        {
            await _service.ChangeNameAsync(request);

            return NoContent();
        }
    }
}
