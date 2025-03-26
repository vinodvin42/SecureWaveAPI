using SecureWave.Models;
using SecureWaveAPI.Repositories.Interfaces;

namespace SecureWaveAPI.Repositories
{
    public class ComplianceCheckRepository : IComplianceCheckRepository
    {
        private readonly List<ComplianceCheck> _complianceChecks = new();

        public Task<IEnumerable<ComplianceCheck>> GetAllComplianceChecksAsync()
        {
            return Task.FromResult(_complianceChecks.AsEnumerable());
        }

        public Task<ComplianceCheck> GetComplianceCheckByIdAsync(Guid id)
        {
            var complianceCheck = _complianceChecks.FirstOrDefault(c => c.ComplianceId == id);
            return Task.FromResult(complianceCheck);
        }

        public Task CreateComplianceCheckAsync(ComplianceCheck complianceCheck)
        {
            _complianceChecks.Add(complianceCheck);
            return Task.CompletedTask;
        }

        public Task UpdateComplianceCheckAsync(ComplianceCheck complianceCheck)
        {
            var existingComplianceCheck = _complianceChecks.FirstOrDefault(c => c.ComplianceId == complianceCheck.ComplianceId);
            if (existingComplianceCheck != null)
            {
                _complianceChecks.Remove(existingComplianceCheck);
                _complianceChecks.Add(complianceCheck);
            }
            return Task.CompletedTask;
        }

        public Task DeleteComplianceCheckAsync(Guid id)
        {
            var complianceCheck = _complianceChecks.FirstOrDefault(c => c.ComplianceId == id);
            if (complianceCheck != null)
            {
                _complianceChecks.Remove(complianceCheck);
            }
            return Task.CompletedTask;
        }
    }
}
