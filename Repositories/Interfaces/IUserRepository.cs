using SecureWave.Models;

namespace SecureWaveAPI.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserByUsernameAsync(string username);
        Task<User> GetUserByEmailAsync(string email);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(Guid id);
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(Guid id);
        Task AddUserRoleAsync(UserRole userRole);
        Task<Role> GetRoleByNameAsync(string roleName);
        Task ResetPasswordAsync(Guid userId, string newPassword);
        Task<User> GetUserByRecoveryTokenAsync(string token);
    }
}