using Microsoft.EntityFrameworkCore;
using SecureWave.Data;
using SecureWave.Models;
using SecureWaveAPI.Models.Dtos;
using SecureWaveAPI.Models.Enums;

namespace SecureWaveAPI.Repositories
{
    public class ResourceRepository : IResourceRepository
    {
        private readonly SecureWaveDbContext _context;

        public ResourceRepository(SecureWaveDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ResourceDto>> GetAllResourcesAsync()
        {
            var resources = await _context.Resources
                .Include(r => r.ResourceTags) // Ensure ResourceTags are loaded
                .ToListAsync();

            return resources.Select(resource => new ResourceDto
            {
                ResourceId = resource.ResourceId,
                ResourceName = resource.ResourceName,
                Description = resource.Description,
                CreatedAt = resource.CreatedAt,
                HostName = resource.HostName,
                Port = (int)resource.Port,
                ApiEndpoint = resource.ApiEndpoint,
                CertificateDetails = resource.CertificateDetails,
                ResourceTags = resource.ResourceTags?.Select(tag => tag.TagName).ToList() ?? new List<string>(), // Map tag names
                ResourceType = Enum.GetName(typeof(ResourceType), resource.ResourceType) ?? "Unknown",
                Protocol = Enum.GetName(typeof(Protocol), resource.Protocol) ?? "Unknown",
                OperatingSystem = Enum.GetName(typeof(Models.Enums.OperatingSystem), resource.OperatingSystem) ?? "Unknown",
                DatabaseType = Enum.GetName(typeof(Models.Enums.DatabaseType), resource.DatabaseType) ?? "Unknown",
                CloudProvider = Enum.GetName(typeof(Models.Enums.CloudProvider), resource.CloudProvider) ?? "Unknown",
                FileSystemType = Enum.GetName(typeof(Models.Enums.FileSystemType), resource.FileSystemType) ?? "Unknown",
                ContainerType = Enum.GetName(typeof(Models.Enums.ContainerType), resource.ContainerType) ?? "Unknown",
                DeviceType = Enum.GetName(typeof(Models.Enums.DeviceType), resource.DeviceType) ?? "Unknown"
            });
        }

        public async Task<Resource> GetResourceByIdAsync(Guid id)
        {
            var resource = await _context.Resources.FindAsync(id);
            if (resource == null)
            {
                throw new KeyNotFoundException($"Resource with id {id} not found.");
            }
            return resource;
        }

        public async Task AddResourceAsync(Resource resource)
        {
            _context.Resources.Add(resource);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateResourceAsync(Resource resource)
        {
            _context.Entry(resource).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteResourceAsync(Guid id)
        {
            var resource = await _context.Resources.FindAsync(id);
            if (resource != null)
            {
                _context.Resources.Remove(resource);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<object>> GetResourceTypesAsync()
        {
            return await Task.FromResult(Enum.GetValues(typeof(ResourceType))
                .Cast<ResourceType>()
                .Select(e => new { Id = (int)e, Value = e.ToString() }));
        }

        public async Task<IEnumerable<object>> GetResourceProtocolAsync()
        {
            return await Task.FromResult(Enum.GetValues(typeof(Protocol))
                .Cast<Protocol>()
                .Select(e => new { Id = (int)e, Value = e.ToString() }));
        }

        public async Task<IEnumerable<object>> GetResourceOperatingSystemAsync()
        {
            return await Task.FromResult(Enum.GetValues(typeof(Models.Enums.OperatingSystem))
                .Cast<Models.Enums.OperatingSystem>()
                .Select(e => new { Id = (int)e, Value = e.ToString() }));
        }

        public async Task<IEnumerable<object>> GetResourceDatabaseTypeAsync()
        {
            return await Task.FromResult(Enum.GetValues(typeof(Models.Enums.DatabaseType))
                .Cast<Models.Enums.DatabaseType>()
                .Select(e => new { Id = (int)e, Value = e.ToString() }));
        }

        public async Task<IEnumerable<object>> GetResourceCloudProviderAsync()
        {
            return await Task.FromResult(Enum.GetValues(typeof(Models.Enums.CloudProvider))
                .Cast<Models.Enums.CloudProvider>()
                .Select(e => new { Id = (int)e, Value = e.ToString() }));
        }

        public async Task<IEnumerable<object>> GetResourceFileSystemTypeAsync()
        {
            return await Task.FromResult(Enum.GetValues(typeof(Models.Enums.FileSystemType))
                .Cast<Models.Enums.FileSystemType>()
                .Select(e => new { Id = (int)e, Value = e.ToString() }));
        }

        public async Task<IEnumerable<object>> GetResourceContainerTypeAsync()
        {
            return await Task.FromResult(Enum.GetValues(typeof(Models.Enums.ContainerType))
                .Cast<Models.Enums.ContainerType>()
                .Select(e => new { Id = (int)e, Value = e.ToString() }));
        }

        public async Task<IEnumerable<object>> GetResourceDeviceTypeAsync()
        {
            return await Task.FromResult(Enum.GetValues(typeof(Models.Enums.DeviceType))
                .Cast<Models.Enums.DeviceType>()
                .Select(e => new { Id = (int)e, Value = e.ToString() }));
        }
    }
}