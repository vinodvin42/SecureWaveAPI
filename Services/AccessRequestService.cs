using SecureWave.Models;
using SecureWaveAPI.Repositories.Interfaces;
using SecureWaveAPI.Services.Interfaces;

namespace SecureWaveAPI.Services
{
    public class AccessRequestService : IAccessRequestService
    {
        private readonly IAccessRequestRepository _accessRequestRepository;

        public AccessRequestService(IAccessRequestRepository accessRequestRepository)
        {
            _accessRequestRepository = accessRequestRepository;
        }

        public IEnumerable<AccessRequest> GetAllAccessRequests()
        {
            return _accessRequestRepository.GetAllAccessRequests();
        }

        public AccessRequest GetAccessRequestById(Guid id)
        {
            return _accessRequestRepository.GetAccessRequestById(id);
        }

        public void CreateAccessRequest(AccessRequest accessRequest)
        {
            _accessRequestRepository.CreateAccessRequest(accessRequest);
        }

        public void UpdateAccessRequest(AccessRequest accessRequest)
        {
            _accessRequestRepository.UpdateAccessRequest(accessRequest);
        }

        public void DeleteAccessRequest(Guid id)
        {
            _accessRequestRepository.DeleteAccessRequest(id);
        }
    }
}
