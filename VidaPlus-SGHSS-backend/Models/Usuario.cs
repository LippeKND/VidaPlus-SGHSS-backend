using System;

namespace SGHSS.Models
{
    public enum UserRole { Admin, Professional, Patient }

    public class Usuario

    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Email { get; set; } = null!;
        public string Senha { get; set; } = null!;
        public UserRole Papel { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
    }
}
