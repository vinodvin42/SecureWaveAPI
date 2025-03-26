using SecureWave.Models;
using SecureWaveAPI.Repositories.Interfaces;
using SecureWaveAPI.Services.Interfaces;

namespace SecureWaveAPI.Services
{
    public class ComplianceCheckService : IComplianceCheckService
    {
        private readonly IComplianceCheckRepository _complianceCheckRepository;

        public ComplianceCheckService(IComplianceCheckRepository complianceCheckRepository)
        {
            _complianceCheckRepository = complianceCheckRepository;
        }

        public async Task<IEnumerable<ComplianceCheck>> GetAllComplianceChecksAsync()
        {
            return await _complianceCheckRepository.GetAllComplianceChecksAsync();
        }

        public async Task<ComplianceCheck> GetComplianceCheckByIdAsync(Guid id)
        {
            return await _complianceCheckRepository.GetComplianceCheckByIdAsync(id);
        }

        public Task CreateComplianceCheckAsync(ComplianceCheck complianceCheck)
        {
            return _complianceCheckRepository.CreateComplianceCheckAsync(complianceCheck);
        }

        public Task UpdateComplianceCheckAsync(ComplianceCheck complianceCheck)
        {
            return _complianceCheckRepository.UpdateComplianceCheckAsync(complianceCheck);
        }

        public Task DeleteComplianceCheckAsync(Guid id)
        {
            return _complianceCheckRepository.DeleteComplianceCheckAsync(id);
        }
    }
}
