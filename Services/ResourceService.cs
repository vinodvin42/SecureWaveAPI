using SecureWave.Models;
using SecureWaveAPI.Models.Enums;
using SecureWaveAPI.Repositories;

namespace SecureWaveAPI.Services
{
    public class ResourceService : IResourceService
    {
        private readonly IResourceRepository _resourceRepository;

        public ResourceService(IResourceRepository resourceRepository)
        {
            _resourceRepository = resourceRepository;
        }

        public async Task<IEnumerable<Resource>> GetAllResourcesAsync()
        {
            return await _resourceRepository.GetAllResourcesAsync();
        }

        public async Task<Resource> GetResourceByIdAsync(Guid id)
        {
            return await _resourceRepository.GetResourceByIdAsync(id);
        }

        public async Task CreateResourceAsync(Resource resource)
        {
            await _resourceRepository.AddResourceAsync(resource);
        }

        public async Task UpdateResourceAsync(Resource resource)
        {
            await _resourceRepository.UpdateResourceAsync(resource);
        }

        public async Task DeleteResourceAsync(Guid id)
        {
            await _resourceRepository.DeleteResourceAsync(id);
        }

        public async Task<IEnumerable<string>> GetResourceTypesAsync()
        {
            return await _resourceRepository.GetResourceTypesAsync();
        }

        public async Task<IEnumerable<string>> GetResourceProtocolAsync()
        {
            return await _resourceRepository.GetResourceProtocolAsync();
        }

        public async Task<IEnumerable<string>> GetResourceOperatingSystemAsync()
        {
            return await _resourceRepository.GetResourceOperatingSystemAsync();
        }

        public async Task<IEnumerable<string>> GetResourceDatabaseTypeAsync()
        {
            return await _resourceRepository.GetResourceDatabaseTypeAsync();
        }

        public async Task<IEnumerable<string>> GetResourceCloudProviderAsync()
        {
            return await _resourceRepository.GetResourceCloudProviderAsync();
        }

        public async Task<IEnumerable<string>> GetResourceFileSystemTypeAsync()
        {
            return await _resourceRepository.GetResourceFileSystemTypeAsync();
        }

        public async Task<IEnumerable<string>> GetResourceContainerTypeAsync()
        {
            return await _resourceRepository.GetResourceContainerTypeAsync();
        }

        public Task<IEnumerable<string>> GetResourceDeviceTypeAsync()
        {
            return _resourceRepository.GetResourceDeviceTypeAsync();
        }
    }
}