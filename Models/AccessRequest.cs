namespace SecureWave.Models
{
    public class AccessRequest
    {
        public Guid RequestId { get; set; }
        public Guid UserId { get; set; }
        public Guid ResourceId { get; set; }
        public string Status { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime? ApprovalDate { get; set; }

        // Navigation properties
        public User User { get; set; }
        public Resource Resource { get; set; }
    }
}