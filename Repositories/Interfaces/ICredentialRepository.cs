﻿using SecureWave.Models;

namespace SecureWaveAPI.Repositories.Interfaces
{
    public interface ICredentialRepository
    {
        Task<IEnumerable<Credential>> GetAllCredentialsAsync();
        Task<Credential> GetCredentialByIdAsync(Guid id);
        Task AddCredentialAsync(Credential credential);
        Task UpdateCredentialAsync(Credential credential);
        Task DeleteCredentialAsync(Guid id);
    }
}
