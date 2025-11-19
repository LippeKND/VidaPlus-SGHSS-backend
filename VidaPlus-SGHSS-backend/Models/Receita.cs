using System;

namespace SGHSS.Models
{
    public class Receita
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid ProntuarioId { get; set; }
        public Prontuairo? Prontuairo { get; set; }
        public Guid? IssuedByProfessionalId { get; set; }
        public string ContentJson { get; set; } = "{}";
        public DateTime IssuedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ValidUntil { get; set; }
    }
}
