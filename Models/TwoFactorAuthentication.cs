using System;

namespace SecureWave.Models
{
    public class TwoFactorAuthentication
    {
        // Primary Key
        public Guid TwoFactorId { get; set; } = Guid.NewGuid();

        // Foreign Key
        public Guid UserId { get; set; } // Foreign Key to User

        // 2FA Details
        public string SecretKey { get; set; } // Secret key for 2FA
        public bool IsEnabled { get; set; } = false; // Whether 2FA is enabled
        public DateTime? LastUsed { get; set; } // Timestamp of last 2FA use

        // Navigation Properties
        public User User { get; set; } // Reference to User
    }
}