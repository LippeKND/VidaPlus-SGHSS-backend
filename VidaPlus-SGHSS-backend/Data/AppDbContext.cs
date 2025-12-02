using Microsoft.EntityFrameworkCore;
using VidaPlus_SGHSS_backend.Models;

namespace VidaPlus_SGHSS_backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios => Set<Usuario>();
        public DbSet<Paciente> Pacientes => Set<Paciente>();
        public DbSet<Medico> Medicos => Set<Medico>();
        public DbSet<Unidade> Unidade => Set<Unidade>();
        public DbSet<Consulta> Consultas => Set<Consulta>();
        public DbSet<Prontuario> Prontuarios => Set<Prontuario>();
        public DbSet<Receita> Receitas => Set<Receita>();
        public DbSet<Leito> Leitos => Set<Leito>();
        public DbSet<Internacao> Internacaos => Set<Internacao>();
        public DbSet<LogsAuditoria> LogsAuditorias => Set<LogsAuditoria>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<Paciente>()
                .HasOne(p => p.Usario)
                .WithMany()
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Medico>()
                .HasOne(m => m.Usuario)
                .WithMany()
                .HasForeignKey(m => m.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Consulta>()
                .HasOne(c => c.Paciente)
                .WithMany(p => p.Consultas)
                .HasForeignKey(c => c.PacienteId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Prontuario>()
                .HasOne(p => p.Paciente)
                .WithMany(p => p.Prontuarios)
                .HasForeignKey(p => p.PacienteId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Receita>()
                .HasOne(r => r.Prontuario)
                .WithMany(p => p.Receitas)
                .HasForeignKey(r => r.ProntuarioId) 
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Internacao>()
                .HasOne(i => i.Paciente)
                .WithMany(p => p.Internacoes)
                .HasForeignKey(i => i.PacienteId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Leito>()
                .HasOne(l => l.Unidades)
                .WithMany(u => u.Leitos)
                .HasForeignKey(l => l.UnitId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}



