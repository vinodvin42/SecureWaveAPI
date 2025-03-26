using SecureWaveAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using SecureWave.Models;
using SecureWave.Data;

namespace SecureWaveAPI.Repositories
{
    public class AccessRequestRepository : IAccessRequestRepository
    {
        private readonly SecureWaveDbContext _context;

        public AccessRequestRepository(SecureWaveDbContext context)
        {
            _context = context;
        }

        public IEnumerable<AccessRequest> GetAllAccessRequests()
        {
            return _context.Set<AccessRequest>().ToList();
        }

        public AccessRequest GetAccessRequestById(Guid id)
        {
            return _context.Set<AccessRequest>().Find(id);
        }

        public void CreateAccessRequest(AccessRequest accessRequest)
        {
            _context.Set<AccessRequest>().Add(accessRequest);
            _context.SaveChanges();
        }

        public void UpdateAccessRequest(AccessRequest accessRequest)
        {
            _context.Set<AccessRequest>().Update(accessRequest);
            _context.SaveChanges();
        }

        public void DeleteAccessRequest(Guid id)
        {
            var accessRequest = GetAccessRequestById(id);
            if (accessRequest != null)
            {
                _context.Set<AccessRequest>().Remove(accessRequest);
                _context.SaveChanges();
            }
        }
    }
}
