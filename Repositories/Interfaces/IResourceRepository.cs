using SecureWave.Models;
using SecureWaveAPI.Models.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecureWaveAPI.Repositories
{
    public interface IResourceRepository
    {
        Task<IEnumerable<Resource>> GetAllResourcesAsync();
        Task<Resource> GetResourceByIdAsync(Guid id);
        Task AddResourceAsync(Resource resource);
        Task UpdateResourceAsync(Resource resource);
        Task DeleteResourceAsync(Guid id);
        Task<IEnumerable<string>> GetResourceTypesAsync();
        Task<IEnumerable<string>> GetResourceProtocolAsync();
        Task<IEnumerable<string>> GetResourceOperatingSystemAsync();
        Task<IEnumerable<string>> GetResourceDatabaseTypeAsync();
        Task<IEnumerable<string>> GetResourceCloudProviderAsync();
        Task<IEnumerable<string>> GetResourceFileSystemTypeAsync();
        Task<IEnumerable<string>> GetResourceContainerTypeAsync();
        Task<IEnumerable<string>> GetResourceDeviceTypeAsync();
     }
}