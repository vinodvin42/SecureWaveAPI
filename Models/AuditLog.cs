using System;

namespace SecureWave.Models
{
    public class AuditLog
    {
        // Primary Key
        public Guid LogId { get; set; } = Guid.NewGuid();

        // Foreign Key
        public Guid UserId { get; set; } // Foreign Key to User

        // Log Details
        public string Action { get; set; } // Action performed (e.g., Login, AccessRequest)
        public DateTime Timestamp { get; set; } = DateTime.UtcNow; // Timestamp of action
        public string Details { get; set; } // Additional details about the action

        // Navigation Properties
        public User User { get; set; } // Reference to User
    }
}