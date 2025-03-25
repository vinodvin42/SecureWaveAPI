using Microsoft.EntityFrameworkCore;
using SecureWave.Data;
using SecureWave.Models;
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

        public async Task<IEnumerable<Resource>> GetAllResourcesAsync()
        {
            return await _context.Resources.ToListAsync();
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
        public async Task<IEnumerable<string>> GetResourceTypesAsync()
        {
            return await Task.FromResult(Enum.GetNames(typeof(ResourceType)));
        }

        public async Task<IEnumerable<string>> GetResourceProtocolAsync()
        {
            return await Task.FromResult(Enum.GetNames(typeof(Protocol)));
        }

        public async Task<IEnumerable<string>> GetResourceOperatingSystemAsync()
        {
            return await Task.FromResult(Enum.GetNames(typeof(Models.Enums.OperatingSystem)));
        }

        public async Task<IEnumerable<string>> GetResourceDatabaseTypeAsync()
        {
            return await Task.FromResult(Enum.GetNames(typeof(Models.Enums.DatabaseType)));
        }

        public async Task<IEnumerable<string>> GetResourceCloudProviderAsync()
        {
            return await Task.FromResult(Enum.GetNames(typeof(Models.Enums.CloudProvider)));
        }

        public async Task<IEnumerable<string>> GetResourceFileSystemTypeAsync()
        {
            return await Task.FromResult(Enum.GetNames(typeof(Models.Enums.FileSystemType)));
        }

        public async Task<IEnumerable<string>> GetResourceContainerTypeAsync()
        {
            return await Task.FromResult(Enum.GetNames(typeof(Models.Enums.ContainerType)));
        }

        public async Task<IEnumerable<string>> GetResourceDeviceTypeAsync()
        {
            return await Task.FromResult(Enum.GetNames(typeof(Models.Enums.DeviceType)));
        }
    }
}