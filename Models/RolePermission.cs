namespace SecureWave.Models
{
    public class RolePermission
    {
        // Primary Key
        public Guid PermissionId { get; set; } = Guid.NewGuid();

        // Foreign Key
        public Guid RoleId { get; set; } // Foreign Key to Role

        // Permission Details
        public string PermissionName { get; set; } // Name of the permission (e.g., Read, Write)
        public string Description { get; set; } // Description of the permission

        // Navigation Properties
        public Role Role { get; set; } // Reference to Role
    }
}