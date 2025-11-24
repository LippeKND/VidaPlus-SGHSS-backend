using System;
using System.Collections.Generic;

namespace VidaPlus_SGHSS_backend.Models
{
    public class Paciente   
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UserId { get; set; }
        public Usuario? Usario { get; set; }
        public string FullName { get; set; } = null!;
        public string? Cpf { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public bool ConsentLgpd { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<Consulta>? Consultas { get; set; }
        public ICollection<Prontuairo>? Prontuairos { get; set; }
        public ICollection<Internacao>? Internacoes { get; set; }
    }
}
