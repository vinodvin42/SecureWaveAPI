using Microsoft.AspNetCore.Mvc;
using SecureWave.Models;
using SecureWaveAPI.Models.DTOs;
using SecureWaveAPI.Services.Interfaces;

namespace SecureWaveAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CredentialsController : ControllerBase
    {
        private readonly ICredentialService _credentialService;

        public CredentialsController(ICredentialService credentialService)
        {
            _credentialService = credentialService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CredentialDTO>>> GetAllCredentials()
        {
            var credentials = await _credentialService.GetAllCredentialsAsync();
            return Ok(credentials);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CredentialDTO>> GetCredentialById(Guid id)
        {
            var credential = await _credentialService.GetCredentialByIdAsync(id);
            if (credential == null)
            {
                return NotFound();
            }
            return Ok(credential);
        }

        [HttpPost]
        public async Task<ActionResult> CreateCredential(CredentialDTO credentialDto)
        {
            var credential = new Credential
            {
                ResourceId = credentialDto.ResourceId,
                Username = credentialDto.Username,
                Password = credentialDto.Password,
                ExpiresAt = credentialDto.ExpiresAt
            };
            await _credentialService.AddCredentialAsync(credential);
            return CreatedAtAction(nameof(GetCredentialById), new { id = credential.CredentialId }, credential);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCredential(Guid id, CredentialDTO credentialDto)
        {
            var credential = await _credentialService.GetCredentialByIdAsync(id);
            if (credential == null)
            {
                return NotFound();
            }
            credential.Username = credentialDto.Username;
            credential.Password = credentialDto.Password;
            credential.ExpiresAt = credentialDto.ExpiresAt;
            await _credentialService.UpdateCredentialAsync(credential);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCredential(Guid id)
        {
            var credential = await _credentialService.GetCredentialByIdAsync(id);
            if (credential == null)
            {
                return NotFound();
            }
            await _credentialService.DeleteCredentialAsync(id);
            return NoContent();
        }
    }
}
