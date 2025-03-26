using SecureWaveAPI.Services.Interfaces;
using System.Security.Claims;

namespace SecureWave.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<CurrentUserService> _logger;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor, ILogger<CurrentUserService> logger)
        {
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
        }

        public Guid GetCurrentUserId()
        {
            _logger.LogDebug("Attempting to get current user ID.");
            var userIdClaim = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (Guid.TryParse(userIdClaim, out var userId))
            {
                _logger.LogDebug("Successfully retrieved user ID: {UserId}", userId);
                return userId;
            }
            _logger.LogWarning("User ID not found in claims.");
            throw new UnauthorizedAccessException("User ID not found in claims.");
        }

        public string GetCurrentUsername()
        {
            _logger.LogDebug("Attempting to get current username.");
            var usernameClaim = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Name)?.Value;
            if (string.IsNullOrEmpty(usernameClaim))
            {
                _logger.LogWarning("Username not found in claims.");
                throw new UnauthorizedAccessException("Username not found in claims.");
            }
            _logger.LogDebug("Successfully retrieved username: {Username}", usernameClaim);
            return usernameClaim;
        }

        public string GetCurrentUserRole()
        {
            _logger.LogDebug("Attempting to get current user role.");
            var roleClaim = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Role)?.Value;
            if (string.IsNullOrEmpty(roleClaim))
            {
                _logger.LogWarning("Role not found in claims.");
                throw new UnauthorizedAccessException("Role not found in claims.");
            }
            _logger.LogDebug("Successfully retrieved user role: {Role}", roleClaim);
            return roleClaim;
        }
    }
}