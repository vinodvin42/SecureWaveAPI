using SecureWaveAPI.Models.Enums;

namespace SecureWave.Models
{
    public class Resource
    {
        // Primary Key
        public Guid ResourceId { get; set; } = Guid.NewGuid();

        // Resource Details
        public string ResourceName { get; set; } // Name of the resource (e.g., "Production Server 1")
        public ResourceType ResourceType { get; set; } // Type of resource (e.g., Server, Database)
        public string Description { get; set; } // Description of the resource
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Timestamp of creation

        // Additional Fields for Resource-Specific Details
        public string HostName { get; set; } // Hostname or IP address
        public int? Port { get; set; } // Port number (if applicable)
        public Protocol Protocol { get; set; } // Protocol (e.g., SSH, RDP)
        public SecureWaveAPI.Models.Enums.OperatingSystem OperatingSystem { get; set; } // OS (e.g., Linux, Windows)
        public DatabaseType DatabaseType { get; set; } // Database type (e.g., MySQL, PostgreSQL)
        public CloudProvider CloudProvider { get; set; } // Cloud provider (e.g., AWS, Azure)
        public string ApiEndpoint { get; set; } // API endpoint (e.g., https://api.example.com)
        public FileSystemType FileSystemType { get; set; } // File system type (e.g., S3, NFS)
        public ContainerType ContainerType { get; set; } // Container type (e.g., Docker, Kubernetes)
        public DeviceType DeviceType { get; set; } // Device type (e.g., IoT, Printer)

        // Navigation Properties
        public ICollection<Credential> Credentials { get; set; } = new List<Credential>(); // One-to-Many with Credentials
        public ICollection<AccessRequest> AccessRequests { get; set; } = new List<AccessRequest>(); // One-to-Many with AccessRequests
        public ICollection<Session> Sessions { get; set; } = new List<Session>(); // One-to-Many with Sessions
        public ICollection<ResourceTag> ResourceTags { get; set; } = new List<ResourceTag>(); // Many-to-Many with ResourceTags
    }
}

//Explanation of Fields
//ResourceName: Name of the resource(e.g., "Production Server 1").
//ResourceType: Type of resource(e.g., Server, Database, Cloud).
//Description: Description of the resource(e.g., "Primary database for customer data").
//HostName: Hostname or IP address of the resource.
//Port: Port number for accessing the resource(e.g., 22 for SSH, 3306 for MySQL).
//Protocol: Protocol used to access the resource(e.g., SSH, RDP, HTTP).
//OperatingSystem: Operating system of the resource(e.g., Linux, Windows).
//DatabaseType: Type of database(e.g., MySQL, PostgreSQL, MongoDB).
//CloudProvider: Cloud provider(e.g., AWS, Azure, Google Cloud).
//ApiEndpoint: API endpoint(e.g., https://api.example.com).
//FileSystemType: Type of file system (e.g., S3, NFS, FTP).
//ContainerType: Type of container (e.g., Docker, Kubernetes).
//DeviceType: Type of device (e.g., IoT Device, Printer).

