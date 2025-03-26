namespace SecureWave.Models
{
    public class ComplianceCheck
    {
        // Primary Key
        public Guid ComplianceId { get; set; } = Guid.NewGuid();

        // Compliance Details
        public string CheckName { get; set; } // Name of the compliance check
        public string Description { get; set; } // Description of the check
        public DateTime CheckDate { get; set; } = DateTime.UtcNow; // Timestamp of the check
        public bool IsCompliant { get; set; } = false; // Whether the check passed

        // Navigation Properties
        public ICollection<AuditLog> AuditLogs { get; set; } = new List<AuditLog>(); // One-to-Many with AuditLogs
    }
}