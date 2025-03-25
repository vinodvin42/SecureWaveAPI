using Microsoft.AspNetCore.Mvc;
using SecureWave.Models;
using SecureWaveAPI.Services;

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

        [HttpGet("operatingsystem")]
        public async Task<ActionResult> GetResourceOperatingSystemAsync()
        {
            var resourceOperatingSystem = await _resourceService.GetResourceOperatingSystemAsync();
            return Ok(resourceOperatingSystem);
        }

        [HttpGet("databasetype")]
        public async Task<ActionResult> GetResourceDatabaseTypeAsync()
        {
            var databaseType = await _resourceService.GetResourceDatabaseTypeAsync();
            return Ok(databaseType);
        }

        [HttpGet("cloudprovider")]
        public async Task<ActionResult> GetResourceCloudProviderAsync()
        {
            var cloudProvider = await _resourceService.GetResourceCloudProviderAsync();
            return Ok(cloudProvider);
        }

        [HttpGet("filesystemtype")]
        public async Task<ActionResult> GetResourceFileSystemTypeAsync()
        {
            var fileSystemTypes = await _resourceService.GetResourceFileSystemTypeAsync();
            return Ok(fileSystemTypes);
        }

        [HttpGet("containertype")]
        public async Task<ActionResult> GetResourceContainerTypeAsync()
        {
            var containerTypes = await _resourceService.GetResourceContainerTypeAsync();
            return Ok(containerTypes);
        }

        [HttpGet("devicetype")]
        public async Task<ActionResult> GetResourceDeviceTypeAsync()
        {
            var deviceTypes = await _resourceService.GetResourceDeviceTypeAsync();
            return Ok(deviceTypes);
        }
    }
}