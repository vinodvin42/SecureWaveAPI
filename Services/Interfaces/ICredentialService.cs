using SecureWave.Models;

namespace SecureWaveAPI.Services.Interfaces
{
    public interface ICredentialService
    {
        Task<IEnumerable<Credential>> GetAllCredentialsAsync();
        Task<Credential> GetCredentialByIdAsync(Guid id);
        Task AddCredentialAsync(Credential credential);
        Task UpdateCredentialAsync(Credential credential);
        Task DeleteCredentialAsync(Guid id);
    }
}
