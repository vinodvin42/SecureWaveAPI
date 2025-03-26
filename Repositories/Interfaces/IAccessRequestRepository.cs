using SecureWave.Models;
using System.Threading.Tasks;

namespace SecureWaveAPI.Repositories.Interfaces
{
    public interface IAccessRequestRepository
    {
        Task<IEnumerable<AccessRequest>> GetAllAccessRequestsAsync();
        Task<AccessRequest> GetAccessRequestByIdAsync(Guid id);
        Task CreateAccessRequestAsync(AccessRequest accessRequest);
        Task UpdateAccessRequestAsync(AccessRequest accessRequest);
        Task DeleteAccessRequestAsync(Guid id);
    }
}
