using System;

namespace SecureWave.Models
{
    public class APIKey
    {
        // Primary Key
        public Guid KeyId { get; set; } = Guid.NewGuid();

        // Foreign Key
        public Guid UserId { get; set; } // Foreign Key to User

        // API Key Details
        public string KeyValue { get; set; } // Encrypted API key
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Timestamp of creation
        public DateTime? ExpiresAt { get; set; } // Expiration date of the key
        public bool IsActive { get; set; } = true; // Whether the key is active

        // Navigation Properties
        public User User { get; set; } // Reference to User
    }
}