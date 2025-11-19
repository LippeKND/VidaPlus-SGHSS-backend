using System;
using System.Collections.Generic;

namespace SGHSS.Models
{
    public class Leito
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UnitId { get; set; }
        public Unit? Unit { get; set; }
        public string? Label { get; set; }
        public string Status { get; set; } = "free"; // free|occupied|maintenance
        public ICollection<Internacao>? Internacaos { get; set; }
    }
}
