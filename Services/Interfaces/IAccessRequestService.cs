using SecureWave.Models;

namespace SecureWaveAPI.Services.Interfaces
{
    public interface IAccessRequestService
    {
        IEnumerable<AccessRequest> GetAllAccessRequests();
        AccessRequest GetAccessRequestById(Guid id);
        void CreateAccessRequest(AccessRequest accessRequest);
        void UpdateAccessRequest(AccessRequest accessRequest);
        void DeleteAccessRequest(Guid id);
    }
}
