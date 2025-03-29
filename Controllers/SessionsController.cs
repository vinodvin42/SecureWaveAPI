using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using SecureWave.Models;
using SecureWaveAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecureWaveAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionsController : ControllerBase
    {
        private readonly ISessionService _sessionService;

        public SessionsController(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Session>>> GetAllSessions()
        {
            return Ok(await _sessionService.GetAllSessionsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Session>> GetSessionById(Guid id)
        {
            var session = await _sessionService.GetSessionByIdAsync(id);
            if (session == null)
            {
                return NotFound();
            }
            return Ok(session);
        }

        [HttpPost]
        public async Task<ActionResult<Session>> CreateSession(Session session)
        {
            await _sessionService.CreateSessionAsync(session);
            return CreatedAtAction(nameof(GetSessionById), new { id = session.SessionId }, session);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSession(Guid id, Session session)
        {
            if (id != session.SessionId)
            {
                return BadRequest();
            }

            await _sessionService.UpdateSessionAsync(session);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSession(Guid id)
        {
            var session = await _sessionService.GetSessionByIdAsync(id);
            if (session == null)
            {
                return NotFound();
            }

            await _sessionService.DeleteSessionAsync(id);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchSession(Guid id, [FromBody] JsonPatchDocument<Session> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest("Invalid patch document.");
            }

            var session = await _sessionService.GetSessionByIdAsync(id);
            if (session == null)
            {
                return NotFound($"Session with ID {id} not found.");
            }

            // Apply the patch document to the session object
            patchDoc.ApplyTo(session);

            // Validate the patched object
            if (!TryValidateModel(session))
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _sessionService.UpdateSessionPartialAsync(session);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

            return NoContent();
        }
    }
}
