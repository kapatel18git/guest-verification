using Microsoft.EntityFrameworkCore;
using GuestVerification.Core.Entities;

namespace GuestVerification.Data
{
    public class GuestVerificationDbContext : DbContext
    {
        public GuestVerificationDbContext(DbContextOptions<GuestVerificationDbContext> options)
            : base(options)
        {
        }

        public DbSet<GuestWhitelist> WhitelistEntries { get; set; } = null!;
        public DbSet<VerificationLog> VerificationLogs { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // GuestWhitelist configuration
            modelBuilder.Entity<GuestWhitelist>()
                .HasKey(w => w.Id);

            modelBuilder.Entity<GuestWhitelist>()
                .HasIndex(w => w.MobileNumber)
                .IsUnique();

            modelBuilder.Entity<GuestWhitelist>()
                .Property(w => w.MobileNumber)
                .HasMaxLength(15)
                .IsRequired();

            // VerificationLog configuration
            modelBuilder.Entity<VerificationLog>()
                .HasKey(l => l.Id);

            modelBuilder.Entity<VerificationLog>()
                .Property(l => l.MobileNumber)
                .HasMaxLength(15)
                .IsRequired();

            modelBuilder.Entity<VerificationLog>()
                .HasIndex(l => l.VerifiedAt);
        }
    }
}
