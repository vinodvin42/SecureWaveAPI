using Microsoft.AspNetCore.Mvc;
using SecureWave.Models;
using SecureWaveAPI.Services.Interfaces;

namespace SecureWaveAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComplianceChecksController : ControllerBase
    {
        private readonly IComplianceCheckService _complianceCheckService;

        public ComplianceChecksController(IComplianceCheckService complianceCheckService)
        {
            _complianceCheckService = complianceCheckService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllComplianceChecks()
        {
            var complianceChecks = await _complianceCheckService.GetAllComplianceChecksAsync();
            return Ok(complianceChecks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetComplianceCheckById(Guid id)
        {
            var complianceCheck = await _complianceCheckService.GetComplianceCheckByIdAsync(id);
            if (complianceCheck == null)
            {
                return NotFound();
            }
            return Ok(complianceCheck);
        }

        [HttpPost]
        public async Task<IActionResult> CreateComplianceCheck([FromBody] ComplianceCheck complianceCheck)
        {
            if (complianceCheck == null)
            {
                return BadRequest();
            }

            await _complianceCheckService.CreateComplianceCheckAsync(complianceCheck);
            return CreatedAtAction(nameof(GetComplianceCheckById), new { id = complianceCheck.ComplianceId }, complianceCheck);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateComplianceCheck(Guid id, [FromBody] ComplianceCheck complianceCheck)
        {
            if (complianceCheck == null || complianceCheck.ComplianceId != id)
            {
                return BadRequest();
            }

            var existingComplianceCheck = await _complianceCheckService.GetComplianceCheckByIdAsync(id);
            if (existingComplianceCheck == null)
            {
                return NotFound();
            }

            await _complianceCheckService.UpdateComplianceCheckAsync(complianceCheck);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComplianceCheck(Guid id)
        {
            var existingComplianceCheck = await _complianceCheckService.GetComplianceCheckByIdAsync(id);
            if (existingComplianceCheck == null)
            {
                return NotFound();
            }

            await _complianceCheckService.DeleteComplianceCheckAsync(id);
            return NoContent();
        }
    }
}
