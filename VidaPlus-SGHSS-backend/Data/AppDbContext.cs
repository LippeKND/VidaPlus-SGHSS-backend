using Microsoft.EntityFrameworkCore;
using SGHSS.Models;
using System.Collections.Generic;
using VidaPlus_SGHSS_backend.Models;

namespace VidaPlus_SGHSS_backend.Data
{
    public class AppDbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Consulta> Consultas { get; set; }
    }
}
