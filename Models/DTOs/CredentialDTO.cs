namespace SecureWaveAPI.Models.DTOs
{
    public class CredentialDTO
    {
        public Guid ResourceId { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}
