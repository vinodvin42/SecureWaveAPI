using Microsoft.AspNetCore.Mvc;
using SecureWave.Models;
using SecureWaveAPI.Models.Enums;
using SecureWaveAPI.Services;
using System.Security.AccessControl;

namespace SecureWave.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourceController : ControllerBase
    {
        private readonly IResourceService _resourceService;

        public ResourceController(IResourceService resourceService)
        {
            _resourceService = resourceService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Resource>>> GetResources()
        {
            var resources = await _resourceService.GetAllResourcesAsync();
            return Ok(resources);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Resource>> GetResource(Guid id)
        {
            var resource = await _resourceService.GetResourceByIdAsync(id);
            if (resource == null)
            {
                return NotFound();
            }
            return Ok(resource);
        }

        [HttpPost]
        public async Task<ActionResult<Resource>> CreateResource([FromBody] Resource resource)
        {
            if (resource == null)
            {
                return BadRequest();
            }

            await _resourceService.CreateResourceAsync(resource);
            return CreatedAtAction(nameof(GetResource), new { id = resource.ResourceId }, resource);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateResource(Guid id, [FromBody] Resource resource)
        {
            if (resource == null || resource.ResourceId != id)
            {
                return BadRequest();
            }

            await _resourceService.UpdateResourceAsync(resource);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteResource(Guid id)
        {
            await _resourceService.DeleteResourceAsync(id);
            return NoContent();
        }

        [HttpGet("type")]
        public async Task<ActionResult> GetResourceTypes()
        {
            var resourceTypes = await _resourceService.GetResourceTypesAsync();
            return Ok(resourceTypes);
        }

        [HttpGet("protocol")]
        public async Task<ActionResult> GetResourceProtocolAsync()
        {
            var resourceProtocall = await _resourceService.GetResourceProtocolAsync();
            return Ok(resourceProtocall);
        }
    }
}