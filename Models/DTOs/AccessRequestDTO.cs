namespace SecureWaveAPI.Models.DTOs
{
    public class AccessRequestDTO
    {
        public Guid Id { get; set; }
        public string RequesterName { get; set; }
        public string RequesterEmail { get; set; }
        public string ResourceName { get; set; }
        public string ResourceType { get; set; }
        public string AccessLevel { get; set; }
        public DateTime RequestDate { get; set; }
        public string Status { get; set; }
        public string Comments { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public string ApproverName { get; set; }
    }
}
