﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SecureWave.Data;

#nullable disable

namespace SecureWaveAPI.Migrations
{
    [DbContext(typeof(SecureWaveDbContext))]
    partial class SecureWaveDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ResourceResourceTag", b =>
                {
                    b.Property<Guid>("ResourceTagsTagId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ResourcesResourceId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ResourceTagsTagId", "ResourcesResourceId");

                    b.HasIndex("ResourcesResourceId");

                    b.ToTable("ResourceResourceTag");
                });

            modelBuilder.Entity("SecureWave.Models.AccessRequest", b =>
                {
                    b.Property<Guid>("RequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ApprovalDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ResourceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RequestId");

                    b.HasIndex("ResourceId");

                    b.HasIndex("UserId");

                    b.ToTable("AccessRequests");
                });

            modelBuilder.Entity("SecureWave.Models.AuditLog", b =>
                {
                    b.Property<Guid>("LogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ComplianceCheckComplianceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LogId");

                    b.HasIndex("ComplianceCheckComplianceId");

                    b.HasIndex("UserId");

                    b.ToTable("AuditLogs");
                });

            modelBuilder.Entity("SecureWave.Models.ComplianceCheck", b =>
                {
                    b.Property<Guid>("ComplianceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CheckDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CheckName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsCompliant")
                        .HasColumnType("bit");

                    b.HasKey("ComplianceId");

                    b.ToTable("ComplianceChecks");
                });

            modelBuilder.Entity("SecureWave.Models.Credential", b =>
                {
                    b.Property<Guid>("CredentialId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExpiresAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ResourceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CredentialId");

                    b.HasIndex("ResourceId");

                    b.ToTable("Credentials");
                });

            modelBuilder.Entity("SecureWave.Models.Notification", b =>
                {
                    b.Property<Guid>("NotificationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsRead")
                        .HasColumnType("bit");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("NotificationId");

                    b.HasIndex("UserId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("SecureWave.Models.Resource", b =>
                {
                    b.Property<Guid>("ResourceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ApiEndpoint")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CertificateDetails")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CloudProvider")
                        .HasColumnType("int");

                    b.Property<int>("ContainerType")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("DatabaseType")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DeviceType")
                        .HasColumnType("int");

                    b.Property<int>("FileSystemType")
                        .HasColumnType("int");

                    b.Property<string>("HostName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OperatingSystem")
                        .HasColumnType("int");

                    b.Property<int?>("Port")
                        .HasColumnType("int");

                    b.Property<int>("Protocol")
                        .HasColumnType("int");

                    b.Property<string>("ResourceName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ResourceType")
                        .HasColumnType("int");

                    b.HasKey("ResourceId");

                    b.ToTable("Resources");
                });

            modelBuilder.Entity("SecureWave.Models.ResourceTag", b =>
                {
                    b.Property<Guid>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TagName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TagId");

                    b.ToTable("ResourceTag");
                });

            modelBuilder.Entity("SecureWave.Models.Role", b =>
                {
                    b.Property<Guid>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            RoleId = new Guid("e3b1b363-8bd9-402a-b186-ccaca4b3053e"),
                            Description = "Administrator role with full access",
                            RoleName = "Admin"
                        },
                        new
                        {
                            RoleId = new Guid("d27787c4-4ab6-4ddc-8e02-c093482f2868"),
                            Description = "Auditor role with read-only access",
                            RoleName = "Auditor"
                        },
                        new
                        {
                            RoleId = new Guid("2517c88a-d394-434e-8c71-ca12259c5d4c"),
                            Description = "Standard user role with limited access",
                            RoleName = "User"
                        });
                });

            modelBuilder.Entity("SecureWave.Models.Session", b =>
                {
                    b.Property<Guid>("SessionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ResourceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SessionData")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("SessionId");

                    b.HasIndex("ResourceId");

                    b.HasIndex("UserId");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("SecureWave.Models.TwoFactorAuthentication", b =>
                {
                    b.Property<Guid>("TwoFactorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastUsed")
                        .HasColumnType("datetime2");

                    b.Property<string>("SecretKey")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("TwoFactorId");

                    b.HasIndex("UserId");

                    b.ToTable("TwoFactorAuthentications");
                });

            modelBuilder.Entity("SecureWave.Models.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AccessJustification")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AccessLevel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FailedLoginAttempts")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsLdapUser")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastLogin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastPasswordChange")
                        .HasColumnType("datetime2");

                    b.Property<string>("LdapDn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LockoutEndTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("PasswordExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RecoveryToken")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RecoveryTokenExpiry")
                        .HasColumnType("datetime2");

                    b.Property<bool>("RequiresMFA")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("SessionTimeout")
                        .HasColumnType("datetime2");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("8d5b3473-c1aa-4614-91c7-eb5b7d1dae07"),
                            AccessJustification = "System Administrator",
                            AccessLevel = "Admin",
                            CreatedAt = new DateTime(2025, 3, 26, 18, 42, 38, 738, DateTimeKind.Utc).AddTicks(4156),
                            Email = "admin@securewave.com",
                            FailedLoginAttempts = 0,
                            IsActive = true,
                            IsDeleted = false,
                            IsLdapUser = false,
                            LdapDn = "cn=admin,dc=securewave,dc=com",
                            PasswordHash = "wNOloL96fqhqN2lmof5W/w==:/GeuITtvIG0sim737oL3dY2VDAKpNuPdSAFq2KVeBm8=",
                            RecoveryToken = "",
                            RequiresMFA = false,
                            Username = "admin"
                        });
                });

            modelBuilder.Entity("SecureWave.Models.UserRole", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("8d5b3473-c1aa-4614-91c7-eb5b7d1dae07"),
                            RoleId = new Guid("e3b1b363-8bd9-402a-b186-ccaca4b3053e")
                        });
                });

            modelBuilder.Entity("ResourceResourceTag", b =>
                {
                    b.HasOne("SecureWave.Models.ResourceTag", null)
                        .WithMany()
                        .HasForeignKey("ResourceTagsTagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SecureWave.Models.Resource", null)
                        .WithMany()
                        .HasForeignKey("ResourcesResourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SecureWave.Models.AccessRequest", b =>
                {
                    b.HasOne("SecureWave.Models.Resource", "Resource")
                        .WithMany("AccessRequests")
                        .HasForeignKey("ResourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SecureWave.Models.User", "User")
                        .WithMany("AccessRequests")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Resource");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SecureWave.Models.AuditLog", b =>
                {
                    b.HasOne("SecureWave.Models.ComplianceCheck", null)
                        .WithMany("AuditLogs")
                        .HasForeignKey("ComplianceCheckComplianceId");

                    b.HasOne("SecureWave.Models.User", "User")
                        .WithMany("AuditLogs")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SecureWave.Models.Credential", b =>
                {
                    b.HasOne("SecureWave.Models.Resource", "Resource")
                        .WithMany("Credentials")
                        .HasForeignKey("ResourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Resource");
                });

            modelBuilder.Entity("SecureWave.Models.Notification", b =>
                {
                    b.HasOne("SecureWave.Models.User", "User")
                        .WithMany("Notifications")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SecureWave.Models.Session", b =>
                {
                    b.HasOne("SecureWave.Models.Resource", "Resource")
                        .WithMany("Sessions")
                        .HasForeignKey("ResourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SecureWave.Models.User", "User")
                        .WithMany("Sessions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Resource");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SecureWave.Models.TwoFactorAuthentication", b =>
                {
                    b.HasOne("SecureWave.Models.User", "User")
                        .WithMany("TwoFactorAuthentications")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SecureWave.Models.UserRole", b =>
                {
                    b.HasOne("SecureWave.Models.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SecureWave.Models.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SecureWave.Models.ComplianceCheck", b =>
                {
                    b.Navigation("AuditLogs");
                });

            modelBuilder.Entity("SecureWave.Models.Resource", b =>
                {
                    b.Navigation("AccessRequests");

                    b.Navigation("Credentials");

                    b.Navigation("Sessions");
                });

            modelBuilder.Entity("SecureWave.Models.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("SecureWave.Models.User", b =>
                {
                    b.Navigation("AccessRequests");

                    b.Navigation("AuditLogs");

                    b.Navigation("Notifications");

                    b.Navigation("Sessions");

                    b.Navigation("TwoFactorAuthentications");

                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
