
namespace VidaPlus_SGHSS_backend.Models
{
    public class Prontuairo
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid PacienteId { get; set; }
        public Paciente? Paciente { get; set; }
        public Guid? ProfessionalId { get; set; }
        public Medico? Medico { get; set; }
        public Guid? ConsultaId { get; set; }
        public string? Note { get; set; }
        public string? Diagnosis { get; set; }
        public string? AttachmentsJson { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<Receita>? Receitas { get; set; }
    }
}
