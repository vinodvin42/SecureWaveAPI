namespace SecureWave.Models
{
    public class UserActivityLog
    {
        // Primary Key
        public Guid ActivityId { get; set; } = Guid.NewGuid();

        // Foreign Key
        public Guid UserId { get; set; } // Foreign Key to User

        // Activity Details
        public string Action { get; set; } // Action performed (e.g., Login, Logout)
        public DateTime Timestamp { get; set; } = DateTime.UtcNow; // Timestamp of the activity
        public string Details { get; set; } // Additional details about the activity

        // Navigation Properties
        public User User { get; set; } // Reference to User
    }
}