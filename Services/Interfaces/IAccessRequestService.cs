using SecureWave.Models;
using System.Threading.Tasks;

namespace SecureWaveAPI.Services.Interfaces
{
    public interface IAccessRequestService
    {
        Task<IEnumerable<AccessRequest>> GetAllAccessRequestsAsync();
        Task<AccessRequest> GetAccessRequestByIdAsync(Guid id);
        Task CreateAccessRequestAsync(AccessRequest accessRequest);
        Task UpdateAccessRequestAsync(AccessRequest accessRequest);
        Task DeleteAccessRequestAsync(Guid id);
        Task ApproveAccessRequestAsync(Guid id);
    }
}
