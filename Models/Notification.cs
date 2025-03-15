using System;

namespace SecureWave.Models
{
    public class Notification
    {
        // Primary Key
        public Guid NotificationId { get; set; } = Guid.NewGuid();

        // Foreign Key
        public Guid UserId { get; set; } // Foreign Key to User

        // Notification Details
        public string Message { get; set; } // Notification message
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Timestamp of creation
        public bool IsRead { get; set; } = false; // Whether the notification has been read

        // Navigation Properties
        public User User { get; set; } // Reference to User
    }
}