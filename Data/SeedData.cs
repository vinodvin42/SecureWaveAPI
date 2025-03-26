using Microsoft.EntityFrameworkCore;
using SecureWave.Models;
using SecureWaveAPI.Utilities;

public static class SeedData
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        // Seed Roles
        var roles = new List<Role>
        {
            new Role { RoleId = Guid.NewGuid(), RoleName = "Admin", Description = "Administrator role with full access" },
            new Role { RoleId = Guid.NewGuid(), RoleName = "Auditor", Description = "Auditor role with read-only access" },
            new Role { RoleId = Guid.NewGuid(), RoleName = "User", Description = "Standard user role with limited access" }
        };
        modelBuilder.Entity<Role>().HasData(roles);

        // Seed Users
        var adminRoleId = roles[0].RoleId;
        var users = new List<User>
        {
            new User
            {
                UserId = Guid.NewGuid(), // Explicitly set a unique Guid
                Username = "admin",
                PasswordHash = PasswordHasher.HashPassword("Admin@123"),
                Email = "admin@securewave.com",
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
                AccessLevel = "Admin",
                AccessJustification = "System Administrator", // Provide a value for AccessJustification
                SessionTimeout = null, // Optional: Set to null or a specific value
                IsDeleted = false,
                DeletedAt = null,
                RecoveryToken = "", // Provide a value for RecoveryToken (e.g., empty string)
                RecoveryTokenExpiry = null,
                IsLdapUser = false,
                LdapDn = "cn=admin,dc=securewave,dc=com" // Provide a value for LdapDn
            }
        };
        modelBuilder.Entity<User>().HasData(users);

        // Seed UserRoles
        var userRoles = new List<UserRole>
        {
            new UserRole { UserId = users[0].UserId, RoleId = adminRoleId }
        };
        modelBuilder.Entity<UserRole>().HasData(userRoles);
    }
}