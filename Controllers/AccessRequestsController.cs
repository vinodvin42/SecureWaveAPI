using Microsoft.AspNetCore.Mvc;
using SecureWave.Models;
using SecureWaveAPI.Services.Interfaces;

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
        public IActionResult GetAllAccessRequests()
        {
            var accessRequests = _accessRequestService.GetAllAccessRequests();
            return Ok(accessRequests);
        }

        [HttpGet("{id}")]
        public IActionResult GetAccessRequestById(Guid id)
        {
            var accessRequest = _accessRequestService.GetAccessRequestById(id);
            if (accessRequest == null)
            {
                return NotFound();
            }
            return Ok(accessRequest);
        }

        [HttpPost]
        public IActionResult CreateAccessRequest([FromBody] AccessRequest accessRequest)
        {
            if (accessRequest == null)
            {
                return BadRequest();
            }
            _accessRequestService.CreateAccessRequest(accessRequest);
            return CreatedAtAction(nameof(GetAccessRequestById), new { id = accessRequest.RequestId }, accessRequest);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAccessRequest(Guid id, [FromBody] AccessRequest accessRequest)
        {
            if (accessRequest == null || accessRequest.RequestId != id)
            {
                return BadRequest();
            }
            var existingAccessRequest = _accessRequestService.GetAccessRequestById(id);
            if (existingAccessRequest == null)
            {
                return NotFound();
            }
            _accessRequestService.UpdateAccessRequest(accessRequest);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAccessRequest(Guid id)
        {
            var existingAccessRequest = _accessRequestService.GetAccessRequestById(id);
            if (existingAccessRequest == null)
            {
                return NotFound();
            }
            _accessRequestService.DeleteAccessRequest(id);
            return NoContent();
        }
    }
}
