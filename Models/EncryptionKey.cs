namespace SecureWave.Models
{
    public class EncryptionKey
    {
        // Primary Key
        public Guid KeyId { get; set; } = Guid.NewGuid();

        // Key Details
        public string KeyName { get; set; } // Name of the key
        public string KeyValue { get; set; } // Encrypted key value
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Timestamp of creation
        public bool IsActive { get; set; } = true; // Whether the key is active
    }
}