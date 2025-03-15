namespace SecureWave.Models
{
    public class ResourcePermission
    {
        // Primary Key
        public Guid ResourcePermissionId { get; set; } = Guid.NewGuid();

        // Foreign Keys
        public Guid RoleId { get; set; } // Foreign Key to Role
        public Guid ResourceId { get; set; } // Foreign Key to Resource

        // Permission Details
        public bool CanRead { get; set; } = false; // Read access
        public bool CanWrite { get; set; } = false; // Write access
        public bool CanDelete { get; set; } = false; // Delete access

        // Navigation Properties
        public Role Role { get; set; } // Reference to Role
        public Resource Resource { get; set; } // Reference to Resource
    }
}