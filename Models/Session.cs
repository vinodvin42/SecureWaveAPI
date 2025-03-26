namespace SecureWave.Models
{
    public class Session
    {
        // Primary Key
        public Guid SessionId { get; set; } = Guid.NewGuid();

        // Foreign Keys
        public Guid UserId { get; set; } // Foreign Key to User
        public Guid ResourceId { get; set; } // Foreign Key to Resource

        // Session Details
        public DateTime StartTime { get; set; } = DateTime.UtcNow; // Timestamp of session start
        public DateTime? EndTime { get; set; } // Timestamp of session end
        public string SessionData { get; set; } // Encrypted session logs or data

        // Navigation Properties
        public User User { get; set; } // Reference to User
        public Resource Resource { get; set; } // Reference to Resource
    }
}