using Microsoft.EntityFrameworkCore;
using SecureWave.Models;

namespace SecureWave.Data
{
    public class SecureWaveDbContext : DbContext
    {
        public SecureWaveDbContext(DbContextOptions<SecureWaveDbContext> options) : base(options)
        {
        }

        // DbSet properties for each entity
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Credential> Credentials { get; set; }
        public DbSet<AccessRequest> AccessRequests { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<ComplianceCheck> ComplianceChecks { get; set; }
        public DbSet<TwoFactorAuthentication> TwoFactorAuthentications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure many-to-many relationship between User and Role
            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new { ur.UserId, ur.RoleId }); // Composite primary key

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId);

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId);

            // Configure one-to-many relationships
            modelBuilder.Entity<Credential>()
                .HasOne(c => c.Resource)
                .WithMany(r => r.Credentials)
                .HasForeignKey(c => c.ResourceId);

            modelBuilder.Entity<ComplianceCheck>()
                .HasKey(cc => cc.ComplianceId);

            modelBuilder.Entity<TwoFactorAuthentication>()
                .HasKey(tfa => tfa.TwoFactorId);

            modelBuilder.Entity<AccessRequest>()
                .HasKey(ar => ar.RequestId);

            modelBuilder.Entity<AccessRequest>()
                .HasOne(ar => ar.User)
                .WithMany(u => u.AccessRequests)
                .HasForeignKey(ar => ar.UserId);

            modelBuilder.Entity<AccessRequest>()
                .HasOne(ar => ar.Resource)
                .WithMany(r => r.AccessRequests)
                .HasForeignKey(ar => ar.ResourceId);

            // Add additional properties and relationships for AccessRequest
            modelBuilder.Entity<AccessRequest>()
                .Property(ar => ar.Status)
                .IsRequired();

            modelBuilder.Entity<AccessRequest>()
                .Property(ar => ar.RequestDate)
                .IsRequired();

            modelBuilder.Entity<AccessRequest>()
                .Property(ar => ar.ApprovalDate)
                .IsRequired(false);

            modelBuilder.Entity<Session>()
                .HasOne(s => s.User)
                .WithMany(u => u.Sessions)
                .HasForeignKey(s => s.UserId);

            modelBuilder.Entity<Session>()
                .HasOne(s => s.Resource)
                .WithMany(r => r.Sessions)
                .HasForeignKey(s => s.ResourceId);

            modelBuilder.Entity<AuditLog>()
                .HasKey(al => al.LogId);

            modelBuilder.Entity<AuditLog>()
                .HasOne(al => al.User)
                .WithMany(u => u.AuditLogs)
                .HasForeignKey(al => al.UserId);

            modelBuilder.Entity<Notification>()
                .HasOne(n => n.User)
                .WithMany(u => u.Notifications)
                .HasForeignKey(n => n.UserId);

            modelBuilder.Entity<TwoFactorAuthentication>()
                .HasOne(tfa => tfa.User)
                .WithMany(u => u.TwoFactorAuthentications)
                .HasForeignKey(tfa => tfa.UserId);

            modelBuilder.Entity<ResourceTag>()
                .HasKey(rt => rt.TagId);

            // Seed initial data
            SeedData.Seed(modelBuilder);
        }
    }
}