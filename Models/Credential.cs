using System;

namespace SecureWave.Models
{
    public class Credential
    {
        // Primary Key
        public Guid CredentialId { get; set; } = Guid.NewGuid();

        // Foreign Key
        public Guid ResourceId { get; set; } // Foreign Key to Resource

        // Credential Details
        public string Username { get; set; } // Username for the resource
        public string Password { get; set; } // Encrypted password for the resource
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Timestamp of creation
        public DateTime ExpiresAt { get; set; } // Expiration date of the credential

        // Navigation Properties
        public Resource Resource { get; set; } // Reference to Resource
    }
}