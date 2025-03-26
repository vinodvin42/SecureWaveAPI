namespace SecureWave.Models
{
    public class FailedLoginAttempt
    {
        // Primary Key
        public Guid AttemptId { get; set; } = Guid.NewGuid();

        // Foreign Key
        public Guid UserId { get; set; } // Foreign Key to User

        // Attempt Details
        public DateTime AttemptTime { get; set; } = DateTime.UtcNow; // Timestamp of the attempt
        public string IpAddress { get; set; } // IP address of the user
        public string DeviceInfo { get; set; } // Device information (e.g., browser, OS)

        // Navigation Properties
        public User User { get; set; } // Reference to User
    }
}