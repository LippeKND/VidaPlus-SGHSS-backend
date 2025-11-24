using System;

namespace VidaPlus_SGHSS_backend.Models
{
    public enum UserRole { Admin, Medico, Paciente }

    public class Usuario

    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Email { get; set; } = null!;
        public string Senha { get; set; } = null!;
        public UserRole Papel { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
    }
}
