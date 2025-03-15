using SecureWave.Models;
using SecureWaveAPI.Models.Enums;

namespace SecureWaveAPI.Services
{
    public interface IResourceService
    {
        Task<IEnumerable<Resource>> GetAllResourcesAsync();
        Task<Resource> GetResourceByIdAsync(Guid id);
        Task CreateResourceAsync(Resource resource);
        Task UpdateResourceAsync(Resource resource);
        Task DeleteResourceAsync(Guid id);
        Task<IEnumerable<string>> GetResourceTypesAsync();
        Task<IEnumerable<string>> GetResourceProtocolAsync();
    }
}