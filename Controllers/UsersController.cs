using Microsoft.AspNetCore.Mvc;
using SecureWaveAPI.Models.DTOs;
using SecureWaveAPI.Services.Interfaces;

namespace SecureWaveAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ICurrentUserService _currentUserService;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IUserService userService, ICurrentUserService currentUserService, ILogger<UsersController> logger)
        {
            _userService = userService;
            _currentUserService = currentUserService;
            _logger = logger;
        }


        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            var currentUserId = _currentUserService.GetCurrentUserId(); // Get the current user's ID
            var currentUsername = _currentUserService.GetCurrentUsername(); // Get the current user's username
            var currentUserRole = _currentUserService.GetCurrentUserRole(); // Get the current user's role

            // Example: Only allow Admins to view all users
            if (currentUserRole != "Admin" && currentUserRole != "SuperAdmin")
            {
                return Forbid(); // Deny access if the user is not an Admin
            }

            var users = await _userService.GetAllUsersAsync();

            return Ok(users);
        }

        // GET: api/Users/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUser(Guid id)
        {
            var currentUserId = _currentUserService.GetCurrentUserId(); // Get the current user's ID
            var currentUsername = _currentUserService.GetCurrentUsername(); // Get the current user's username
            var currentUserRole = _currentUserService.GetCurrentUserRole(); // Get the current user's role

            // Example: Only allow Admins to view all users
            if (currentUserRole != "Admin")
            {
                return Forbid(); // Deny access if the user is not an Admin
            }

            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<UserDTO>> CreateUser(UserDTO userDto)
        {
            _logger.LogDebug("Received request to create user: {@UserDto}", userDto);

            if (string.IsNullOrEmpty(userDto.Password))
            {
                _logger.LogWarning("Password field is required.");
                return BadRequest("The Password field is required.");
            }

            try
            {
                var createdUser = await _userService.CreateUserAsync(userDto);
                return CreatedAtAction(nameof(GetUser), new { id = createdUser.UserId }, createdUser);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating user.");
                return StatusCode(500, "Internal server error");
            }
        }

        // PUT: api/Users/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, UserDTO userDto)
        {
            if (id != userDto.UserId)
            {
                return BadRequest();
            }

            // Check if the password field is empty and remove it from the update if it is
            if (string.IsNullOrEmpty(userDto.Password))
            {
                userDto.Password = ""; // Set password to null to indicate no update
            }

            await _userService.UpdateUserAsync(userDto);
            return NoContent();
        }

        // DELETE: api/Users/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }

        // POST: api/Users/{id}/EnableMFA
        [HttpPost("{id}/EnableMFA")]
        public async Task<IActionResult> EnableMFA(Guid id)
        {
            await _userService.EnableMFAAsync(id);
            return NoContent();
        }

        // POST: api/Users/{id}/DisableMFA
        [HttpPost("{id}/DisableMFA")]
        public async Task<IActionResult> DisableMFA(Guid id)
        {
            await _userService.DisableMFAAsync(id);
            return NoContent();
        }

        // POST: api/Users/{id}/ResetPassword
        [HttpPost("{id}/ResetPassword")]
        public async Task<IActionResult> ResetPassword(Guid id, [FromBody] string newPassword)
        {
            await _userService.ResetPasswordAsync(id, newPassword);
            return NoContent();
        }

        // POST: api/Users/{id}/Lockout
        [HttpPost("{id}/Lockout")]
        public async Task<IActionResult> LockoutUser(Guid id, [FromBody] DateTime lockoutEndTime)
        {
            await _userService.LockoutUserAsync(id, lockoutEndTime);
            return NoContent();
        }

        // POST: api/Users/{id}/Unlock
        [HttpPost("{id}/Unlock")]
        public async Task<IActionResult> UnlockUser(Guid id)
        {
            await _userService.UnlockUserAsync(id);
            return NoContent();
        }
    }
}