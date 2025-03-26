namespace SecureWave.Models
{
    public class TemporaryAccess
    {
        // Primary Key
        public Guid AccessId { get; set; } = Guid.NewGuid();

        // Foreign Keys
        public Guid UserId { get; set; } // Foreign Key to User
        public Guid ResourceId { get; set; } // Foreign Key to Resource

        // Access Details
        public DateTime StartTime { get; set; } // Start time of access
        public DateTime EndTime { get; set; } // End time of access
        public bool IsActive { get; set; } = true; // Whether the access is active

        // Navigation Properties
        public User User { get; set; } // Reference to User
        public Resource Resource { get; set; } // Reference to Resource
    }
}