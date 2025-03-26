using SecureWaveAPI.Repositories.Interfaces;
using SecureWave.Models;
using SecureWave.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecureWaveAPI.Repositories
{
    public class SessionRepository : ISessionRepository
    {
        private readonly SecureWaveDbContext _context;

        public SessionRepository(SecureWaveDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Session>> GetAllSessionsAsync()
        {
            return await _context.Set<Session>().ToListAsync();
        }

        public async Task<Session> GetSessionByIdAsync(Guid id)
        {
            return await _context.Set<Session>().FindAsync(id);
        }

        public async Task CreateSessionAsync(Session session)
        {
            await _context.Set<Session>().AddAsync(session);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSessionAsync(Session session)
        {
            _context.Set<Session>().Update(session);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSessionAsync(Guid id)
        {
            var session = await GetSessionByIdAsync(id);
            if (session != null)
            {
                _context.Set<Session>().Remove(session);
                await _context.SaveChangesAsync();
            }
        }
    }
}
