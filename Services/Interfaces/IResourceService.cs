using SecureWave.Models;
using SecureWaveAPI.Models.Dtos;

namespace SecureWaveAPI.Services
{
    public interface IResourceService
    {
        Task<IEnumerable<ResourceDto>> GetAllResourcesAsync();
        Task<Resource> GetResourceByIdAsync(Guid id);
        Task CreateResourceAsync(Resource resource);
        Task UpdateResourceAsync(Resource resource);
        Task DeleteResourceAsync(Guid id);
        Task<IEnumerable<object>> GetResourceTypesAsync();
        Task<IEnumerable<object>> GetResourceProtocolAsync();
        Task<IEnumerable<object>> GetResourceOperatingSystemAsync();
        Task<IEnumerable<object>> GetResourceDatabaseTypeAsync();
        Task<IEnumerable<object>> GetResourceCloudProviderAsync();
        Task<IEnumerable<object>> GetResourceFileSystemTypeAsync();
        Task<IEnumerable<object>> GetResourceContainerTypeAsync();
        Task<IEnumerable<object>> GetResourceDeviceTypeAsync();
    }
}