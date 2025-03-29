namespace SecureWaveAPI.Models.Dtos
{
    public class ResourceDto
    {
        public Guid ResourceId { get; set; }
        public string ResourceName { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public string HostName { get; set; }
        public int Port { get; set; }
        public string ApiEndpoint { get; set; }
        public string CertificateDetails { get; set; }
        public IEnumerable<string> ResourceTags { get; set; }
        public string ResourceType { get; set; }
        public string Protocol { get; set; }
        public string OperatingSystem { get; set; }
        public string DatabaseType { get; set; }
        public string CloudProvider { get; set; }
        public string FileSystemType { get; set; }
        public string ContainerType { get; set; }
        public string DeviceType { get; set; }
    }
}
