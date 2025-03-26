using SecureWave.Models;

namespace SecureWaveAPI.Repositories.Interfaces
{
    public interface IComplianceCheckRepository
    {
        Task<IEnumerable<ComplianceCheck>> GetAllComplianceChecksAsync();
        Task<ComplianceCheck> GetComplianceCheckByIdAsync(Guid id);
        Task CreateComplianceCheckAsync(ComplianceCheck complianceCheck);
        Task UpdateComplianceCheckAsync(ComplianceCheck complianceCheck);
        Task DeleteComplianceCheckAsync(Guid id);
    }
}
