using SecureWave.Models;
using SecureWaveAPI.Models.DTOs;
using SecureWaveAPI.Models.Enums;
using SecureWaveAPI.Repositories.Interfaces;
using SecureWaveAPI.Services.Interfaces;
using SecureWaveAPI.Utilities;

namespace SecureWave.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly IRoleRepository _roleRepository;

        public UserService(IUserRepository userRepository, ICurrentUserService currentUserService, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _currentUserService = currentUserService;
            _roleRepository = roleRepository;
        }

        //get token for password recovery
        public async Task<string> GenerateRecoveryTokenAsync(string email)
        {
            var user = await _userRepository.GetUserByEmailAsync(email);
            if (user == null)
            {
                throw new Exception("User not found.");
            }

            var token = PasswordHasher.GenerateRandomToken();
            user.RecoveryToken = token;
            user.RecoveryTokenExpiry = DateTime.UtcNow.AddHours(1); // Token expires in 1 hour
            await _userRepository.UpdateUserAsync(user);

            return token;
        }

        // Set a recovery token for a user
        public async Task SetRecoveryTokenAsync(Guid userId, string token)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user == null)
            {
                throw new Exception("User not found.");
            }

            user.RecoveryToken = token;
            user.RecoveryTokenExpiry = DateTime.UtcNow.AddHours(1); // Token expires in 1 hour
            await _userRepository.UpdateUserAsync(user);
        }

        // Validate a recovery token
        public async Task<User> ValidateRecoveryTokenAsync(string token)
        {
            var user = await _userRepository.GetUserByRecoveryTokenAsync(token);
            if (user == null)
            {
                throw new Exception("Invalid or expired token.");
            }

            return user;
        }

        public async Task<User> AuthenticateAsync(string username, string password)
        {
            var user = await _userRepository.GetUserByUsernameAsync(username);
            if (user == null || !PasswordHasher.VerifyPassword(password, user.PasswordHash))
            {
                return null; // Invalid username or password
            }
            return user;
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            var currentUserRole = _currentUserService.GetCurrentUserRole(); // Get the current user's role

            // Example: Only allow Admins to view all users
            if (currentUserRole != "Admin" && currentUserRole != "SuperAdmin")
            {
                throw new UnauthorizedAccessException("You do not have permission to view all users.");
            }

            var users = await _userRepository.GetAllUsersAsync();
            return users.Select(u => new UserDTO
            {
                UserId = u.UserId,
                Username = u.Username,
                Email = u.Email,
                IsActive = u.IsActive,
                CreatedAt = u.CreatedAt,
                LastLogin = u.LastLogin,
                RequiresMFA = u.RequiresMFA,
                FailedLoginAttempts = u.FailedLoginAttempts,
                LockoutEndTime = u.LockoutEndTime,
                LastPasswordChange = u.LastPasswordChange,
                PasswordExpiryDate = u.PasswordExpiryDate,
                AccessLevel = u.AccessLevel,
                SessionTimeout = u.SessionTimeout,
                AccessJustification = u.AccessJustification,
                IsDeleted = u.IsDeleted,
                DeletedAt = u.DeletedAt,
                IsLdapUser = u.IsLdapUser,
                LdapDn = u.LdapDn
            });
        }

        public async Task<UserDTO> GetUserByIdAsync(Guid id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                return null;
            }
            return new UserDTO
            {
                UserId = user.UserId,
                Username = user.Username,
                Email = user.Email,
                IsActive = user.IsActive,
                CreatedAt = user.CreatedAt,
                LastLogin = user.LastLogin,
                RequiresMFA = user.RequiresMFA,
                FailedLoginAttempts = user.FailedLoginAttempts,
                LockoutEndTime = user.LockoutEndTime,
                LastPasswordChange = user.LastPasswordChange,
                PasswordExpiryDate = user.PasswordExpiryDate,
                AccessLevel = user.AccessLevel,
                SessionTimeout = user.SessionTimeout,
                AccessJustification = user.AccessJustification,
                IsDeleted = user.IsDeleted,
                DeletedAt = user.DeletedAt,
                IsLdapUser = user.IsLdapUser,
                LdapDn = user.LdapDn
            };
        }

        public async Task<UserDTO> CreateUserAsync(UserDTO userDto)
        {
            // Validate input
            if (userDto == null)
            {
                throw new ArgumentNullException(nameof(userDto), "User data cannot be null.");
            }

            // Check if the username or email already exists
            var existingUserByUsername = await _userRepository.GetUserByUsernameAsync(userDto.Username);
            if (existingUserByUsername != null)
            {
                throw new InvalidOperationException("Username is already taken.");
            }

            var existingUserByEmail = await _userRepository.GetUserByEmailAsync(userDto.Email);
            if (existingUserByEmail != null)
            {
                throw new InvalidOperationException("Email is already registered.");
            }

            // Hash the password
            var passwordHash = PasswordHasher.HashPassword(userDto.Password);

            // Create a new User entity
            var user = new User
            {
                Username = userDto.Username,
                PasswordHash = passwordHash,
                Email = userDto.Email,
                IsActive = true, // Default to active
                CreatedAt = DateTime.UtcNow,
                AccessLevel = RoleType.User.ToString(), // Default role
                RequiresMFA = userDto.RequiresMFA,
                IsLdapUser = userDto.IsLdapUser,
                LdapDn = userDto.LdapDn,
                RecoveryToken = string.Empty,
                AccessJustification = userDto.AccessJustification
            };

            // Add the user to the database
            await _userRepository.AddUserAsync(user);

            // Assign the default role (e.g., "User")
            var defaultRole = await _roleRepository.GetRoleByNameAsync(RoleType.User.ToString());
            if (defaultRole == null)
            {
                throw new InvalidOperationException("Default role not found.");
            }

            var userRole = new UserRole
            {
                UserId = user.UserId,
                RoleId = defaultRole.RoleId
            };

            await _userRepository.AddUserRoleAsync(userRole);

            // Map the User entity back to a UserDTO
            var createdUserDto = new UserDTO
            {
                UserId = user.UserId,
                Username = user.Username,
                Email = user.Email,
                IsActive = user.IsActive,
                CreatedAt = user.CreatedAt,
                AccessLevel = user.AccessLevel,
                RequiresMFA = user.RequiresMFA,
                IsLdapUser = user.IsLdapUser,
                LdapDn = user.LdapDn
            };

            return createdUserDto;
        }

        public async Task UpdateUserAsync(UserDTO userDto)
        {
            var user = await _userRepository.GetUserByIdAsync(userDto.UserId);
            if (user != null)
            {
                user.Username = userDto.Username;
                user.Email = userDto.Email;
                user.IsActive = userDto.IsActive;
                user.RequiresMFA = userDto.RequiresMFA;
                user.AccessLevel = userDto.AccessLevel;
                user.IsLdapUser = userDto.IsLdapUser;
                user.LdapDn = userDto.LdapDn;

                // Update password only if it is not null or empty
                if (!string.IsNullOrEmpty(userDto.Password))
                {
                    user.PasswordHash = PasswordHasher.HashPassword(userDto.Password);
                }

                await _userRepository.UpdateUserAsync(user);
            }
        }

        public async Task DeleteUserAsync(Guid id)
        {
            await _userRepository.DeleteUserAsync(id);
        }

        public async Task EnableMFAAsync(Guid id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user != null)
            {
                user.RequiresMFA = true;
                await _userRepository.UpdateUserAsync(user);
            }
        }

        public async Task DisableMFAAsync(Guid id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user != null)
            {
                user.RequiresMFA = false;
                await _userRepository.UpdateUserAsync(user);
            }
        }

        public async Task ResetPasswordAsync(Guid id, string newPassword)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user != null)
            {
                user.PasswordHash = PasswordHasher.HashPassword(newPassword);
                user.LastPasswordChange = DateTime.UtcNow;
                await _userRepository.UpdateUserAsync(user);
            }
        }

        public async Task LockoutUserAsync(Guid id, DateTime lockoutEndTime)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user != null)
            {
                user.IsActive = false;
                user.LockoutEndTime = lockoutEndTime;
                await _userRepository.UpdateUserAsync(user);
            }
        }

        public async Task UnlockUserAsync(Guid id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user != null)
            {
                user.LockoutEndTime = null;
                user.IsActive = true;
                await _userRepository.UpdateUserAsync(user);
            }
        }

        public async Task<UserDTO> GetUserByEmailAsync(string email)
        {
            var user = await _userRepository.GetUserByEmailAsync(email);

            if (user == null)
            {
                return null;
            }

            return new UserDTO
            {
                UserId = user.UserId,
                Username = user.Username,
                Email = user.Email,
                IsActive = user.IsActive,
                CreatedAt = user.CreatedAt,
                LastLogin = user.LastLogin,
                RequiresMFA = user.RequiresMFA,
                FailedLoginAttempts = user.FailedLoginAttempts,
                LockoutEndTime = user.LockoutEndTime,
                LastPasswordChange = user.LastPasswordChange,
                PasswordExpiryDate = user.PasswordExpiryDate,
                AccessLevel = user.AccessLevel,
                SessionTimeout = user.SessionTimeout,
                AccessJustification = user.AccessJustification,
                IsDeleted = user.IsDeleted,
                DeletedAt = user.DeletedAt,
                IsLdapUser = user.IsLdapUser,
                LdapDn = user.LdapDn
            };
        }
    }
}