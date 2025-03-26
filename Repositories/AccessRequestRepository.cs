using SecureWaveAPI.Repositories.Interfaces;
using SecureWave.Models;
using SecureWave.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SecureWaveAPI.Repositories
{
    public class AccessRequestRepository : IAccessRequestRepository
    {
        private readonly SecureWaveDbContext _context;

        public AccessRequestRepository(SecureWaveDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AccessRequest>> GetAllAccessRequestsAsync()
        {
            return await _context.Set<AccessRequest>().ToListAsync();
        }

        public async Task<AccessRequest> GetAccessRequestByIdAsync(Guid id)
        {
            //fix this warning 
            
            return await _context.Set<AccessRequest>().FindAsync(id);
        }

        public async Task CreateAccessRequestAsync(AccessRequest accessRequest)
        {
            await _context.Set<AccessRequest>().AddAsync(accessRequest);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAccessRequestAsync(AccessRequest accessRequest)
        {
            _context.Set<AccessRequest>().Update(accessRequest);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAccessRequestAsync(Guid id)
        {
            var accessRequest = await GetAccessRequestByIdAsync(id);
            if (accessRequest != null)
            {
                _context.Set<AccessRequest>().Remove(accessRequest);
                await _context.SaveChangesAsync();
            }
        }
    }
}
