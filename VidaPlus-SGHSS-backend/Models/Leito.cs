using System;
using System.Collections.Generic;

namespace VidaPlus_SGHSS_backend.Models
{
    public class Leito
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UnitId { get; set; }
        public Unidade? Unidades { get; set; }
        public string? Label { get; set; }
        public string Status { get; set; } = "free"; // free|occupied|maintenance
        public ICollection<Internacao>? Internacaos { get; set; }
    }
}
