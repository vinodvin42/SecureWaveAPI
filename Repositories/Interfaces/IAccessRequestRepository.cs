using SecureWave.Models;

namespace SecureWaveAPI.Repositories.Interfaces
{
    public interface IAccessRequestRepository
    {
        IEnumerable<AccessRequest> GetAllAccessRequests();
        AccessRequest GetAccessRequestById(Guid id);
        void CreateAccessRequest(AccessRequest accessRequest);
        void UpdateAccessRequest(AccessRequest accessRequest);
        void DeleteAccessRequest(Guid id);
    }
}
