using SecureWaveAPI.Services.Interfaces;
using SecureWaveAPI.Repositories.Interfaces;
using SecureWave.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecureWaveAPI.Services
{
    public class SessionService : ISessionService
    {
        private readonly ISessionRepository _sessionRepository;

        public SessionService(ISessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }

        public async Task<IEnumerable<Session>> GetAllSessionsAsync()
        {
            return await _sessionRepository.GetAllSessionsAsync();
        }

        public async Task<Session> GetSessionByIdAsync(Guid id)
        {
            return await _sessionRepository.GetSessionByIdAsync(id);
        }

        public async Task CreateSessionAsync(Session session)
        {
            await _sessionRepository.CreateSessionAsync(session);
        }

        public async Task UpdateSessionAsync(Session session)
        {
            await _sessionRepository.UpdateSessionAsync(session);
        }

        public async Task DeleteSessionAsync(Guid id)
        {
            await _sessionRepository.DeleteSessionAsync(id);
        }
    }
}
