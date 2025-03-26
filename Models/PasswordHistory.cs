namespace SecureWave.Models
{
    public class PasswordHistory
    {
        // Primary Key
        public Guid HistoryId { get; set; } = Guid.NewGuid();

        // Foreign Key
        public Guid UserId { get; set; } // Foreign Key to User

        // Password Details
        public string PasswordHash { get; set; } // Hashed password
        public DateTime ChangedAt { get; set; } = DateTime.UtcNow; // Timestamp of password change

        // Navigation Properties
        public User User { get; set; } // Reference to User
    }
}