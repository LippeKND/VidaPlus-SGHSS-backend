using System;
using System.Collections.Generic;

namespace VidaPlus_SGHSS_backend.Models
{
    public class Medico
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UserId { get; set; }
        public Usuario? Usuario { get; set; }
        public string FullName { get; set; } = null!;
        public string? Specialty { get; set; }
        public string? RegistrationNumber { get; set; }
        public string? Phone { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<Consulta>? Consulta { get; set; }
        public ICollection<Prontuairo>? Prontuairos { get; set; }
    }
}
