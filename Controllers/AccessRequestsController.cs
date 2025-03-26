using Microsoft.AspNetCore.Mvc;
using SecureWave.Models;
using SecureWaveAPI.Services.Interfaces;
using System.Threading.Tasks;

namespace SecureWaveAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccessRequestsController : ControllerBase
    {
        private readonly IAccessRequestService _accessRequestService;

        public AccessRequestsController(IAccessRequestService accessRequestService)
        {
            _accessRequestService = accessRequestService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAccessRequests()
        {
            var accessRequests = await _accessRequestService.GetAllAccessRequestsAsync();
            return Ok(accessRequests);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAccessRequestById(Guid id)
        {
            var accessRequest = await _accessRequestService.GetAccessRequestByIdAsync(id);
            if (accessRequest == null)
            {
                return NotFound();
            }
            return Ok(accessRequest);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccessRequest([FromBody] AccessRequest accessRequest)
        {
            if (accessRequest == null)
            {
                return BadRequest();
            }
            await _accessRequestService.CreateAccessRequestAsync(accessRequest);
            return CreatedAtAction(nameof(GetAccessRequestById), new { id = accessRequest.RequestId }, accessRequest);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccessRequest(Guid id, [FromBody] AccessRequest accessRequest)
        {
            if (accessRequest == null || accessRequest.RequestId != id)
            {
                return BadRequest();
            }
            var existingAccessRequest = await _accessRequestService.GetAccessRequestByIdAsync(id);
            if (existingAccessRequest == null)
            {
                return NotFound();
            }
            await _accessRequestService.UpdateAccessRequestAsync(accessRequest);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccessRequest(Guid id)
        {
            var existingAccessRequest = await _accessRequestService.GetAccessRequestByIdAsync(id);
            if (existingAccessRequest == null)
            {
                return NotFound();
            }
            await _accessRequestService.DeleteAccessRequestAsync(id);
            return NoContent();
        }
    }
}
