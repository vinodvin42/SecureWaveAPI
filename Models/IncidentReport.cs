using System;

namespace SecureWave.Models
{
    public class IncidentReport
    {
        // Primary Key
        public Guid IncidentId { get; set; } = Guid.NewGuid();

        // Incident Details
        public string Title { get; set; } // Title of the incident
        public string Description { get; set; } // Description of the incident
        public DateTime ReportedAt { get; set; } = DateTime.UtcNow; // Timestamp of reporting
        public string Status { get; set; } // Status of the incident (e.g., Open, Resolved)

        // Navigation Properties
        public ICollection<AuditLog> AuditLogs { get; set; } = new List<AuditLog>(); // One-to-Many with AuditLogs
    }
}