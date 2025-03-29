using SecureWave.Models;
using SecureWaveAPI.Models.Dtos;

namespace SecureWaveAPI.Repositories
{
    public interface IResourceRepository
    {
        Task<IEnumerable<ResourceDto>> GetAllResourcesAsync();
        Task<Resource> GetResourceByIdAsync(Guid id);
        Task AddResourceAsync(Resource resource);
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