namespace SecureWave.Models
{
    public class Role
    {
        public Guid RoleId { get; set; } = Guid.NewGuid();
        public string RoleName { get; set; }
        public string Description { get; set; }

        // Navigation Properties
        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}