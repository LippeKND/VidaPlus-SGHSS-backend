using VidaPlus_SGHSS_backend.Models;
using BCrypt.Net;

namespace VidaPlus_SGHSS_backend.Data
{
    public static class SeedData
    {
        public static void EnsureSeedData(AppDbContext db)
        {
            if (db.Usuarios.Any())
                return;

            var admin = new Usuario
            {
                Id = Guid.NewGuid(),
                Email = "admin@vidaplus.com",
                Senha = BCrypt.Net.BCrypt.HashPassword("Admin123!"),
                Role = "Admin"
            };

            var medicoUser = new Usuario
            {
                Id = Guid.NewGuid(),
                Email = "dr.joao@vidaplus.com",
                Senha = BCrypt.Net.BCrypt.HashPassword("Prof123!"),
                Role = "Medico"
            };

            var pacienteUser = new Usuario
            {
                Id = Guid.NewGuid(),
                Email = "maria@ex.com",
                Senha = BCrypt.Net.BCrypt.HashPassword("Patient123!"),
                Role = "Paciente"
            };

            db.Usuarios.AddRange(admin, medicoUser, pacienteUser);
            db.SaveChanges();
        }
    }
}
