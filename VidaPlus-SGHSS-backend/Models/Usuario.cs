using System.ComponentModel.DataAnnotations;

namespace VidaPlus_SGHSS_backend.Models
{
    public class Usuario
    {
        public Guid Id { get; set; }

        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Senha { get; set; } = string.Empty;

        [Required]
        public string Role { get; set; } = "Paciente";
    }
}
