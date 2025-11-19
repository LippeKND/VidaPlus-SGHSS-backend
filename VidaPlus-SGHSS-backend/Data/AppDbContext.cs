using Microsoft.EntityFrameworkCore;
using VidaPlus.Api.Models;
using VidaPlus_SGHSS_backend.Models;

namespace VidaPlus.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Paciente> Patients { get; set; }
        public DbSet<Professional> Professionals { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Teleconsultation> Teleconsultations { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // indexes, constraints, etc.
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
        }
    }
}
