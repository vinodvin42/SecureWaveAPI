using SecureWave.Models;
using SecureWaveAPI.Models.DTOs;

namespace SecureWaveAPI.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> AuthenticateAsync(string username, string password);
        Task<IEnumerable<UserDTO>> GetAllUsersAsync();
        Task<UserDTO> GetUserByIdAsync(Guid id);
        Task<UserDTO> CreateUserAsync(UserDTO userDto);
        Task UpdateUserAsync(UserDTO userDto);
        Task DeleteUserAsync(Guid id);
        Task EnableMFAAsync(Guid id);
        Task DisableMFAAsync(Guid id);
        Task ResetPasswordAsync(Guid id, string newPassword);
        Task LockoutUserAsync(Guid id, DateTime lockoutEndTime);
        Task UnlockUserAsync(Guid id);
        Task<string> GenerateRecoveryTokenAsync(string email);
        Task SetRecoveryTokenAsync(Guid userId, string recoveryToken);
        Task<UserDTO> GetUserByEmailAsync(string email);
        Task<User> ValidateRecoveryTokenAsync(string token);
    }
}
