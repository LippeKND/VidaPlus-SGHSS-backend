using System;

namespace SGHSS.Models
{
    public class Internacao
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid PacienteId { get; set; }
        public Paciente? Paciente{ get; set; }
        public Guid LeitoId { get; set; }
        public Leito? Leito { get; set; }
        public DateTime AdmittedAt { get; set; } = DateTime.UtcNow;
        public DateTime? DischargedAt { get; set; }
        public string? Notes { get; set; }
    }
}
