namespace SecureWaveAPI.Models.Enums
{
    public enum RoleType
    {
        // System Owner: Full control over the system
        SuperAdmin,

        // Administrator: Manages users, roles, and resources
        Admin,

        // Auditor: Monitors and audits system activities
        Auditor,

        // Security Officer: Enforces security policies
        SecurityOfficer,

        // Compliance Officer: Ensures regulatory compliance
        ComplianceOfficer,

        // Help Desk: Assists users with technical issues
        HelpDesk,

        // Standard User: Limited access based on permissions
        User,

        // Privileged User: Elevated access to specific resources
        PrivilegedUser,

        // Application User: Non-human user (service account)
        ApplicationUser,

        // Guest User: Temporary access for a limited time
        Guest
    }
}