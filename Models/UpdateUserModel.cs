using System.ComponentModel.DataAnnotations;

namespace SecureWaveAPI.Models
{
    public class UpdateUserModel
    {
        // User Identity
        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        // Security & Compliance
        public bool IsActive { get; set; } = true; // Account activation status
        public bool RequiresMFA { get; set; } = false; // Enforce Multi-Factor Authentication
        public int FailedLoginAttempts { get; set; } = 0; // Track failed logins
        public DateTime? LockoutEndTime { get; set; } // Lockout expiry after failed attempts
        public DateTime? LastPasswordChange { get; set; } // Last password update timestamp
        public DateTime? PasswordExpiryDate { get; set; } // Enforce password expiration

        // Privileged Access Management
        public string AccessLevel { get; set; } // Role-based Access Level (Admin, SuperAdmin, etc.)
        public DateTime? SessionTimeout { get; set; } // Track privileged session expiration
        public string AccessJustification { get; set; } // Reason for elevated access

        // Soft Deletion & Recovery
        public bool IsDeleted { get; set; } = false; // Soft delete flag
        public string RecoveryToken { get; set; } // Token for account recovery
        public DateTime? RecoveryTokenExpiry { get; set; } // Expiry for recovery token

        // LDAP Integration
        public bool IsLdapUser { get; set; } = false; // Indicates if the user is fetched from LDAP
        public string LdapDn { get; set; } // Distinguished Name in LDAP
    }
}
