namespace SecureWave.Models
{
    public class PasswordPolicy
    {
        // Primary Key
        public Guid PolicyId { get; set; } = Guid.NewGuid();

        // Policy Details
        public int MinLength { get; set; } // Minimum password length
        public bool RequireUppercase { get; set; } // Require uppercase letters
        public bool RequireLowercase { get; set; } // Require lowercase letters
        public bool RequireDigit { get; set; } // Require digits
        public bool RequireSpecialChar { get; set; } // Require special characters
        public int ExpiryDays { get; set; } // Password expiry in days
        public int MaxFailedAttempts { get; set; } // Maximum failed login attempts
    }
}