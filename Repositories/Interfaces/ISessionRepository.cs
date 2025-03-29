using SecureWave.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecureWaveAPI.Repositories.Interfaces
{
    public interface ISessionRepository
    {
        Task<IEnumerable<Session>> GetAllSessionsAsync();
        Task<Session> GetSessionByIdAsync(Guid id);
        Task CreateSessionAsync(Session session);
        Task UpdateSessionAsync(Session session);
        Task UpdateSessionPartialAsync(Session session);
        Task DeleteSessionAsync(Guid id);
    }
}
