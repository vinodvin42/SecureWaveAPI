using SecureWave.Models;

namespace SecureWaveAPI.Services.Interfaces
{
    public interface IComplianceCheckService
    {
        Task<IEnumerable<ComplianceCheck>> GetAllComplianceChecksAsync();
        Task<ComplianceCheck> GetComplianceCheckByIdAsync(Guid id);
        Task CreateComplianceCheckAsync(ComplianceCheck complianceCheck);
        Task UpdateComplianceCheckAsync(ComplianceCheck complianceCheck);
        Task DeleteComplianceCheckAsync(Guid id);
    }
}
