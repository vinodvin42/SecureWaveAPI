using System;

namespace SecureWave.Models
{
    public class SessionRecording
    {
        // Primary Key
        public Guid RecordingId { get; set; } = Guid.NewGuid();

        // Foreign Key
        public Guid SessionId { get; set; } // Foreign Key to Session

        // Recording Details
        public string RecordingPath { get; set; } // Path to the recording file
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Timestamp of creation

        // Navigation Properties
        public Session Session { get; set; } // Reference to Session
    }
}