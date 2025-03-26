using Microsoft.EntityFrameworkCore;
using SecureWave.Data;
using SecureWave.Models;
using SecureWaveAPI.Repositories.Interfaces;

namespace SecureWaveAPI.Repositories
{
    public class CredentialRepository : ICredentialRepository
    {
        private readonly SecureWaveDbContext _context;

        public CredentialRepository(SecureWaveDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Credential>> GetAllCredentialsAsync()
        {
            return await _context.Credentials.ToListAsync();
        }

        public async Task<Credential> GetCredentialByIdAsync(Guid id)
        {
            return await _context.Credentials.FirstOrDefaultAsync(c => c.CredentialId == id);
        }

        public async Task AddCredentialAsync(Credential credential)
        {
            _context.Credentials.Add(credential);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCredentialAsync(Credential credential)
        {
            var existingCredential = await _context.Credentials.FirstOrDefaultAsync(c => c.CredentialId == credential.CredentialId);
            if (existingCredential != null)
            {
                existingCredential.Username = credential.Username;
                existingCredential.Password = credential.Password;
                existingCredential.ExpiresAt = credential.ExpiresAt;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteCredentialAsync(Guid id)
        {
            var credential = await _context.Credentials.FirstOrDefaultAsync(c => c.CredentialId == id);
            if (credential != null)
            {
                _context.Credentials.Remove(credential);
                await _context.SaveChangesAsync();
            }
        }
    }
}
