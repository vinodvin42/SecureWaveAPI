using SecureWave.Models;
using SecureWaveAPI.Repositories.Interfaces;
using SecureWaveAPI.Services.Interfaces;
using System.Threading.Tasks;

namespace SecureWaveAPI.Services
{
    public class AccessRequestService : IAccessRequestService
    {
        private readonly IAccessRequestRepository _accessRequestRepository;

        public AccessRequestService(IAccessRequestRepository accessRequestRepository)
        {
            _accessRequestRepository = accessRequestRepository;
        }

        public async Task<IEnumerable<AccessRequest>> GetAllAccessRequestsAsync()
        {
            return await _accessRequestRepository.GetAllAccessRequestsAsync();
        }

        public async Task<AccessRequest> GetAccessRequestByIdAsync(Guid id)
        {
            return await _accessRequestRepository.GetAccessRequestByIdAsync(id);
        }

        public async Task CreateAccessRequestAsync(AccessRequest accessRequest)
        {
            await _accessRequestRepository.CreateAccessRequestAsync(accessRequest);
        }

        public async Task UpdateAccessRequestAsync(AccessRequest accessRequest)
        {
            await _accessRequestRepository.UpdateAccessRequestAsync(accessRequest);
        }

        public async Task DeleteAccessRequestAsync(Guid id)
        {
            await _accessRequestRepository.DeleteAccessRequestAsync(id);
        }

        public async Task ApproveAccessRequestAsync(Guid id)
        {
            var accessRequest = await _accessRequestRepository.GetAccessRequestByIdAsync(id);
            if (accessRequest != null)
            {
                accessRequest.Status = "Approved";
                await _accessRequestRepository.UpdateAccessRequestAsync(accessRequest);
            }
        }
    }
}
