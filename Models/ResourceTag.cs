namespace SecureWave.Models
{
    public class ResourceTag
    {
        // Primary Key
        public Guid TagId { get; set; } = Guid.NewGuid();

        // Tag Details
        public string TagName { get; set; } // Name of the tag (e.g., Environment:Prod)

        // Navigation Properties
        public ICollection<Resource> Resources { get; set; } = new List<Resource>(); // Many-to-Many with Resources
    }
}