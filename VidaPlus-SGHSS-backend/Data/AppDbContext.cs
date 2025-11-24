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
        public DbSet<Prontuairo> Prontuairos => Set<Prontuairo>();
        public DbSet<Receita> Receitas => Set<Receita>();
        public DbSet<Leito> Leitos => Set<Leito>();
        public DbSet<Internacao> Internacaos => Set<Internacao>();
        public DbSet<LogsAuditoria> LogsAuditorias => Set<LogsAuditoria>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Usuario>().HasIndex(u => u.Email).IsUnique();

            modelBuilder.Entity<Paciente>()
                .HasOne(p => p.Usario).WithMany().HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Medico>()
                .HasOne(p => p.Usuario).WithMany().HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Consulta>()
                .HasOne(a => a.Paciente).WithMany(p => p.Consultas).HasForeignKey(a => a.PacienteId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Prontuairo>()
                .HasOne(m => m.Paciente).WithMany(p => p.Prontuairos).HasForeignKey(m => m.PacienteId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Receita>()
                .HasOne(pr => pr.Prontuairo).WithMany(m => m.Receitas).HasForeignKey(pr => pr.Prontuairo).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Internacao>()
                .HasOne(ad => ad.Paciente).WithMany(p => p.Internacoes).HasForeignKey(ad => ad.PacienteId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Leito>()
                .HasOne(b => b.Unidades).WithMany(u => u.Leitos).HasForeignKey(b => b.UnitId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
