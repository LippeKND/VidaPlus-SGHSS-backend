using System;
using System.Collections.Generic;

namespace VidaPlus_SGHSS_backend.Models
{ 

public class Unidade
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = null!;
        public string? Address { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<Leito>? Leitos { get; set; }
        public ICollection<Consulta>? Consultas { get; set; }
    }
}
