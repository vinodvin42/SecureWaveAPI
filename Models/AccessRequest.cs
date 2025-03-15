using System;

namespace SecureWave.Models
{
    public class AccessRequest
    {
        // Primary Key
        public Guid RequestId { get; set; } = Guid.NewGuid();

        // Foreign Keys
        public Guid UserId { get; set; } // Foreign Key to User
        public Guid ResourceId { get; set; } // Foreign Key to Resource

        // Request Details
        public DateTime RequestedAt { get; set; } = DateTime.UtcNow; // Timestamp of request
        public DateTime? ApprovedAt { get; set; } // Timestamp of approval
        public string Status { get; set; } // Status of request (e.g., Pending, Approved, Denied)

        // Navigation Properties
        public User User { get; set; } // Reference to User
        public Resource Resource { get; set; } // Reference to Resource
    }
}