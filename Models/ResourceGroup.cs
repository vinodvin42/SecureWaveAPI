using System;
using System.Collections.Generic;

namespace SecureWave.Models
{
    public class ResourceGroup
    {
        // Primary Key
        public Guid GroupId { get; set; } = Guid.NewGuid();

        // Group Details
        public string GroupName { get; set; } // Name of the group
        public string Description { get; set; } // Description of the group

        // Navigation Properties
        public ICollection<Resource> Resources { get; set; } = new List<Resource>(); // One-to-Many with Resources
    }
}