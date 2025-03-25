using Microsoft.AspNetCore.Identity;
using SecureWave.Models;
using SecureWaveAPI.Repositories.Interfaces;
using SecureWaveAPI.Services.Interfaces;
using SecureWaveAPI.Utilities;

namespace SecureWaveAPI.Services
{
    public class CredentialService : ICredentialService
    {
        private readonly ICredentialRepository _credentialRepository;

        public CredentialService(ICredentialRepository credentialRepository)
        {
            _credentialRepository = credentialRepository;
        }

        public async Task<IEnumerable<Credential>> GetAllCredentialsAsync()
        {
            return await _credentialRepository.GetAllCredentialsAsync();
        }

        public async Task<Credential> GetCredentialByIdAsync(Guid id)
        {
            return await _credentialRepository.GetCredentialByIdAsync(id);
        }

        public async Task AddCredentialAsync(Credential credential)
        {
            //check null
            if (credential.Password == null)
            {
                throw new ArgumentNullException(nameof(credential));
            }

            credential.Password = PasswordHasher.HashPassword(credential.Password);
            await _credentialRepository.AddCredentialAsync(credential);
        }

        public async Task UpdateCredentialAsync(Credential credential)
        {
            //check null
            if (credential.Password == null)
            {
                throw new ArgumentNullException(nameof(credential));
            }

            credential.Password = PasswordHasher.HashPassword(credential.Password);
            await _credentialRepository.UpdateCredentialAsync(credential);
        }

        public async Task DeleteCredentialAsync(Guid id)
        {
            await _credentialRepository.DeleteCredentialAsync(id);
        }
    }
}
