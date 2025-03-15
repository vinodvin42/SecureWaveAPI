using System;

namespace SecureWave.Models
{
    public class BackupCredential
    {
        // Primary Key
        public Guid BackupId { get; set; } = Guid.NewGuid();

        // Foreign Key
        public Guid CredentialId { get; set; } // Foreign Key to Credential

        // Backup Details
        public string BackupUsername { get; set; } // Backup username
        public string BackupPassword { get; set; } // Backup password (encrypted)
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Timestamp of creation

        // Navigation Properties
        public Credential Credential { get; set; } // Reference to Credential
    }
}