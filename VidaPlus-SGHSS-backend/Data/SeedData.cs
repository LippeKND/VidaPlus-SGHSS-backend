using VidaPlus_SGHSS_backend.Models;
using System.Linq;
using BCrypt.Net;


namespace VidaPlus_SGHSS_backend.Data
{
    public static class SeedData
    {
        public static void EnsureSeedData(AppDbContext db)
        {
            if (db.Usuarios.Any()) return;

            var admin = new Usuario{ Email = "admin@vidaplus.com", Senha = BCrypt.Net.BCrypt.HashPassword("Admin123!"), Papel = UserRole.Admin };
            var profUsuario = new Usuario { Email = "dr.joao@vidaplus.com", Senha = BCrypt.Net.BCrypt.HashPassword("Prof123!"), Papel = UserRole.Medico};
            var patUsuario = new Usuario { Email = "maria@ex.com", Senha = BCrypt.Net.BCrypt.HashPassword("Patient123!"), Papel = UserRole.Paciente };

            db.Usuarios.AddRange(admin, profUsuario, patUsuario);
            db.SaveChanges();

            var medico = new Medico{ UserId = profUsuario.Id, FullName = "Dr. João Silva", Specialty = "Cardiologia", RegistrationNumber = "CRM1001", Phone = "11900000001" };
            var paciente = new Paciente { UserId = patUsuario.Id, FullName = "Maria Souza", Cpf = "00000000000", Phone = "11911111111", ConsentLgpd = true };

            db.Medicos.Add(medico);
            db.Pacientes.Add(paciente);
            db.Unidade.Add(new Unidade { Name = "Hospital VidaPlus - Sede", Address = "Av. Principal, 100" });
            db.SaveChanges();

            var unitId = db.Unidade.First().Id;

            var appt = new Consulta { PacienteId = paciente.Id, ProfessionalId = medico.Id, UnitId = unitId, Type = "telemedicine", ScheduledAt = DateTime.UtcNow.AddDays(1), DurationMinutes = 30 };
            db.Consultas.Add(appt);
            db.SaveChanges();

            var prontuairo = new Prontuairo { PacienteId = paciente.Id, ProfessionalId = medico.Id, ConsultaId = appt.Id, Note = "Queixa de dor no peito", Diagnosis = "A confirmar" };
            db.Prontuairos.Add(prontuairo);
            db.SaveChanges();

            db.Receitas.Add(new Receita { ProntuarioId = prontuairo.Id, IssuedByProfessionalId = medico.Id, ContentJson = "{\"medicines\":[{\"name\":\"Dipirona\",\"dose\":\"500mg\",\"freq\":\"8h\"}]}", ValidUntil = DateTime.UtcNow.AddMonths(1) });

            db.Leitos.Add(new Leito { UnitId = unitId, Label = "A101", Status = "free" });
            db.Leitos.Add(new Leito { UnitId = unitId, Label = "A102", Status = "free" });

            db.SaveChanges();
        }
    }
}
