using Microsoft.EntityFrameworkCore;
using SecureWave.Data;
using SecureWave.Models;
using SecureWaveAPI.Repositories.Interfaces;

namespace SecureWaveAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SecureWaveDbContext _context;

        public UserRepository(SecureWaveDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with username {username} not found.");
            }
            return user;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with email {email} not found.");
            }
            return user;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with ID {id} not found.");
            }
            return user;
        }

        public async Task AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Role> GetRoleByNameAsync(string roleName)
        {
            var role = await _context.Roles.FirstOrDefaultAsync(r => r.RoleName == roleName);
            if (role == null)
            {
                throw new KeyNotFoundException($"Role with name {roleName} not found.");
            }
            return role;
        }

        public async Task AddUserRoleAsync(UserRole userRole)
        {
            await _context.UserRoles.AddAsync(userRole);
            await _context.SaveChangesAsync();
        }

        // Reset a user's password
        public async Task ResetPasswordAsync(Guid userId, string HashPassword)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                throw new Exception("User not found.");
            }

            user.PasswordHash = HashPassword; // Hash the new password
            user.RecoveryToken = string.Empty; // Invalidate the recovery token
            user.RecoveryTokenExpiry = null;
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetUserByRecoveryTokenAsync(string token)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.RecoveryToken == token);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with recovery token {token} not found.");
            }
            return user;
        }
    }
}