using System;

namespace VidaPlus_SGHSS_backend.Models
{

    public class LogsAuditoria
    {
        public long Id { get; set; }
        public Guid? UserId { get; set; }
        public string Action { get; set; } = null!;
        public string ResourceType { get; set; } = null!;
        public string ResourceId { get; set; } = null!;
        public string? MetaJson { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}