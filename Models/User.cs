namespace SecureWave.Models
{
    public class User
    {
        public Guid UserId { get; set; } = Guid.NewGuid();
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? LastLogin { get; set; }
        public bool RequiresMFA { get; set; } = false;
        public int FailedLoginAttempts { get; set; } = 0;
        public DateTime? LockoutEndTime { get; set; }
        public DateTime? LastPasswordChange { get; set; }
        public DateTime? PasswordExpiryDate { get; set; }
        public string AccessLevel { get; set; }
        public DateTime? SessionTimeout { get; set; }
        public string AccessJustification { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }
        public string RecoveryToken { get; set; }
        public DateTime? RecoveryTokenExpiry { get; set; }
        public bool IsLdapUser { get; set; } = false;
        public string LdapDn { get; set; }

        // Navigation Properties
        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
        public ICollection<AccessRequest> AccessRequests { get; set; } = new List<AccessRequest>();
        public ICollection<Session> Sessions { get; set; } = new List<Session>();
        public ICollection<AuditLog> AuditLogs { get; set; } = new List<AuditLog>();
        public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
        public ICollection<TwoFactorAuthentication> TwoFactorAuthentications { get; set; } = new List<TwoFactorAuthentication>(); // Corrected property name
    }
}