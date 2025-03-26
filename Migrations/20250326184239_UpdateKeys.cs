using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SecureWaveAPI.Migrations
{
    public partial class UpdateKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("42fc0472-025a-49de-8458-ed4a9ba78271"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("e92a8c42-02bc-4144-a569-478e1b1755da"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("1fd78523-3938-4d0f-96c5-03b8bf9e81c0"), new Guid("4c48ab63-28bb-4ce5-bffe-d39cd585c2e0") });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("1fd78523-3938-4d0f-96c5-03b8bf9e81c0"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("4c48ab63-28bb-4ce5-bffe-d39cd585c2e0"));

            migrationBuilder.RenameColumn(
                name: "RequestedAt",
                table: "AccessRequests",
                newName: "RequestDate");

            migrationBuilder.RenameColumn(
                name: "ApprovedAt",
                table: "AccessRequests",
                newName: "ApprovalDate");

            migrationBuilder.AlterColumn<string>(
                name: "ResourceName",
                table: "Resources",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "HostName",
                table: "Resources",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Resources",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CertificateDetails",
                table: "Resources",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ApiEndpoint",
                table: "Resources",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Credentials",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Credentials",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "Description", "RoleName" },
                values: new object[,]
                {
                    { new Guid("2517c88a-d394-434e-8c71-ca12259c5d4c"), "Standard user role with limited access", "User" },
                    { new Guid("d27787c4-4ab6-4ddc-8e02-c093482f2868"), "Auditor role with read-only access", "Auditor" },
                    { new Guid("e3b1b363-8bd9-402a-b186-ccaca4b3053e"), "Administrator role with full access", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "AccessJustification", "AccessLevel", "CreatedAt", "DeletedAt", "Email", "FailedLoginAttempts", "IsActive", "IsDeleted", "IsLdapUser", "LastLogin", "LastPasswordChange", "LdapDn", "LockoutEndTime", "PasswordExpiryDate", "PasswordHash", "RecoveryToken", "RecoveryTokenExpiry", "RequiresMFA", "SessionTimeout", "Username" },
                values: new object[] { new Guid("8d5b3473-c1aa-4614-91c7-eb5b7d1dae07"), "System Administrator", "Admin", new DateTime(2025, 3, 26, 18, 42, 38, 738, DateTimeKind.Utc).AddTicks(4156), null, "admin@securewave.com", 0, true, false, false, null, null, "cn=admin,dc=securewave,dc=com", null, null, "wNOloL96fqhqN2lmof5W/w==:/GeuITtvIG0sim737oL3dY2VDAKpNuPdSAFq2KVeBm8=", "", null, false, null, "admin" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("e3b1b363-8bd9-402a-b186-ccaca4b3053e"), new Guid("8d5b3473-c1aa-4614-91c7-eb5b7d1dae07") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("2517c88a-d394-434e-8c71-ca12259c5d4c"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("d27787c4-4ab6-4ddc-8e02-c093482f2868"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("e3b1b363-8bd9-402a-b186-ccaca4b3053e"), new Guid("8d5b3473-c1aa-4614-91c7-eb5b7d1dae07") });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("e3b1b363-8bd9-402a-b186-ccaca4b3053e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("8d5b3473-c1aa-4614-91c7-eb5b7d1dae07"));

            migrationBuilder.RenameColumn(
                name: "RequestDate",
                table: "AccessRequests",
                newName: "RequestedAt");

            migrationBuilder.RenameColumn(
                name: "ApprovalDate",
                table: "AccessRequests",
                newName: "ApprovedAt");

            migrationBuilder.AlterColumn<string>(
                name: "ResourceName",
                table: "Resources",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HostName",
                table: "Resources",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Resources",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CertificateDetails",
                table: "Resources",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApiEndpoint",
                table: "Resources",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Credentials",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Credentials",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "Description", "RoleName" },
                values: new object[,]
                {
                    { new Guid("1fd78523-3938-4d0f-96c5-03b8bf9e81c0"), "Administrator role with full access", "Admin" },
                    { new Guid("42fc0472-025a-49de-8458-ed4a9ba78271"), "Standard user role with limited access", "User" },
                    { new Guid("e92a8c42-02bc-4144-a569-478e1b1755da"), "Auditor role with read-only access", "Auditor" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "AccessJustification", "AccessLevel", "CreatedAt", "DeletedAt", "Email", "FailedLoginAttempts", "IsActive", "IsDeleted", "IsLdapUser", "LastLogin", "LastPasswordChange", "LdapDn", "LockoutEndTime", "PasswordExpiryDate", "PasswordHash", "RecoveryToken", "RecoveryTokenExpiry", "RequiresMFA", "SessionTimeout", "Username" },
                values: new object[] { new Guid("4c48ab63-28bb-4ce5-bffe-d39cd585c2e0"), "System Administrator", "Admin", new DateTime(2025, 3, 6, 16, 0, 35, 728, DateTimeKind.Utc).AddTicks(4275), null, "admin@securewave.com", 0, true, false, false, null, null, "cn=admin,dc=securewave,dc=com", null, null, "okzW79VqZ9xawTK7LpjCvw==:J5N/No6A7yhK3j9Qydup6meih5lXOoTiAnuoQeIww/A=", "", null, false, null, "admin" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("1fd78523-3938-4d0f-96c5-03b8bf9e81c0"), new Guid("4c48ab63-28bb-4ce5-bffe-d39cd585c2e0") });
        }
    }
}
