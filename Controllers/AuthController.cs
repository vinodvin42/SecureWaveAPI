using Microsoft.AspNetCore.Mvc;
using SecureWave.DTOs;
using SecureWave.Services;
using SecureWaveAPI.Services.Interfaces;

namespace SecureWave.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly AuthService _authService;
        private readonly IEmailService _emailService;

        public AuthController(IUserService userService, AuthService authService, IEmailService emailService)
        {
            _userService = userService;
            _authService = authService;
            _emailService = emailService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(LoginDTO loginDto)
        {
            // Authenticate the user
            var user = await _userService.AuthenticateAsync(loginDto.Username, loginDto.Password);
            if (user == null)
            {
                return Unauthorized("Invalid username or password");
            }

            if(user.IsActive == false)
            {
                return Unauthorized("User is inactive");
            }

            // Generate a JWT token
            var token = _authService.GenerateJwtToken(user);

            // Return the token
            return Ok(new { Token = token });
        }

        // Forgot Password: Generate and send a recovery token
        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDTO forgotPasswordDto)
        {
            var user = await _userService.GetUserByEmailAsync(forgotPasswordDto.Email);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            // Generate a recovery token
            var recoveryToken = await _userService.GenerateRecoveryTokenAsync(user.Email);
            await _userService.SetRecoveryTokenAsync(user.UserId, recoveryToken);

            // Send recovery token via email
            var recoveryLink = $"https://yourapp.com/reset-password?token={recoveryToken}";
            var emailMessage = $"Click the link to reset your password: {recoveryLink}";
            await _emailService.SendEmailAsync(user.Email, "Password Reset", emailMessage);

            return Ok("Recovery token sent.");
        }

        // Reset Password: Validate the recovery token and reset the password
        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDTO resetPasswordDto)
        {
            try
            {
                // Validate the recovery token
                var user = await _userService.ValidateRecoveryTokenAsync(resetPasswordDto.Token);

                // Reset the password
                await _userService.ResetPasswordAsync(user.UserId, resetPasswordDto.NewPassword);

                return Ok("Password reset successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}