using SecureWave.Models;
using SecureWaveAPI.Models.Dtos;
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

        public async Task<IEnumerable<ResourceDto>> GetAllResourcesAsync()
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

        public async Task<IEnumerable<object>> GetResourceTypesAsync()
        {
            return await _resourceRepository.GetResourceTypesAsync();
        }

        public async Task<IEnumerable<object>> GetResourceProtocolAsync()
        {
            return await _resourceRepository.GetResourceProtocolAsync();
        }

        public async Task<IEnumerable<object>> GetResourceOperatingSystemAsync()
        {
            return await _resourceRepository.GetResourceOperatingSystemAsync();
        }

        public async Task<IEnumerable<object>> GetResourceDatabaseTypeAsync()
        {
            return await _resourceRepository.GetResourceDatabaseTypeAsync();
        }

        public async Task<IEnumerable<object>> GetResourceCloudProviderAsync()
        {
            return await _resourceRepository.GetResourceCloudProviderAsync();
        }

        public async Task<IEnumerable<object>> GetResourceFileSystemTypeAsync()
        {
            return await _resourceRepository.GetResourceFileSystemTypeAsync();
        }

        public async Task<IEnumerable<object>> GetResourceContainerTypeAsync()
        {
            return await _resourceRepository.GetResourceContainerTypeAsync();
        }

        public async Task<IEnumerable<object>> GetResourceDeviceTypeAsync()
        {
            return await _resourceRepository.GetResourceDeviceTypeAsync();
        }
    }
}