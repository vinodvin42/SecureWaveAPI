using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SecureWaveAPI.Models.DTOs
{
    public class UserDTO
    {
        [JsonPropertyName("userId")]
        public Guid UserId { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("lastLogin")]
        public DateTime? LastLogin { get; set; }

        [JsonPropertyName("requiresMFA")]
        public bool RequiresMFA { get; set; }

        [JsonPropertyName("failedLoginAttempts")]
        public int FailedLoginAttempts { get; set; }

        [JsonPropertyName("lockoutEndTime")]
        public DateTime? LockoutEndTime { get; set; }

        [JsonPropertyName("lastPasswordChange")]
        public DateTime? LastPasswordChange { get; set; }

        [JsonPropertyName("passwordExpiryDate")]
        public DateTime? PasswordExpiryDate { get; set; }

        [JsonPropertyName("accessLevel")]
        public string AccessLevel { get; set; }

        [JsonPropertyName("sessionTimeout")]
        public DateTime? SessionTimeout { get; set; }

        [JsonPropertyName("accessJustification")]
        public string AccessJustification { get; set; }

        [JsonPropertyName("isDeleted")]
        public bool IsDeleted { get; set; }

        [JsonPropertyName("deletedAt")]
        public DateTime? DeletedAt { get; set; }

        [JsonPropertyName("isLdapUser")]
        public bool IsLdapUser { get; set; }

        [JsonPropertyName("ldapDn")]
        public string LdapDn { get; set; }

        [JsonPropertyName("password")]
        [Required(AllowEmptyStrings = true)] // Allow empty strings for password
        public string Password { get; set; }
    }
}
