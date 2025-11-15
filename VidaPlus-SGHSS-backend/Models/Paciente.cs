namespace VidaPlus_SGHSS_backend.Models
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }

        // Navegação
        public ICollection<Consulta> Consultas { get; set; }
    }
}
