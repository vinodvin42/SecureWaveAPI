using SecureWaveAPI.Models.Enums;

namespace SecureWaveAPI.Services
{
    public class AccessControlService
    {
        public bool HasPermission(RoleType role, string permission)
        {
            switch (role)
            {
                case RoleType.SuperAdmin:
                    return true; // SuperAdmin has full access
                case RoleType.Admin:
                    return permission switch
                    {
                        "CreateUser" or "UpdateUser" or "DeleteUser" => true,
                        "CreateRole" or "UpdateRole" or "DeleteRole" => true,
                        "CreateResource" or "UpdateResource" or "DeleteResource" => true,
                        "AssignRole" => true,
                        "ConfigureSystemSettings" => true,
                        "ViewAuditLogs" => true,
                        "GenerateComplianceReports" => true,
                        "ApproveAccessRequest" => true,
                        "LockUnlockUser" => true,
                        _ => false
                    };
                case RoleType.Auditor:
                    return permission switch
                    {
                        "ViewAuditLogs" => true,
                        "GenerateComplianceReports" => true,
                        _ => false
                    };
                case RoleType.SecurityOfficer:
                    return permission switch
                    {
                        "ViewAuditLogs" => true,
                        "ApproveAccessRequest" => true,
                        "LockUnlockUser" => true,
                        _ => false
                    };
                case RoleType.ComplianceOfficer:
                    return permission switch
                    {
                        "ViewAuditLogs" => true,
                        "GenerateComplianceReports" => true,
                        _ => false
                    };
                case RoleType.HelpDesk:
                    return permission switch
                    {
                        "ApproveAccessRequest" => true,
                        "LockUnlockUser" => true,
                        _ => false
                    };
                case RoleType.User:
                    return permission switch
                    {
                        "RequestAccess" => true,
                        _ => false
                    };
                case RoleType.PrivilegedUser:
                    return permission switch
                    {
                        "AccessPrivilegedResources" => true,
                        _ => false
                    };
                case RoleType.ApplicationUser:
                    return permission switch
                    {
                        "AccessAPIs" => true,
                        _ => false
                    };
                case RoleType.Guest:
                    return permission switch
                    {
                        "RequestAccess" => true,
                        _ => false
                    };
                default:
                    return false;
            }
        }
    }
}