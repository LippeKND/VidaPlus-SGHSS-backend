namespace SGHSS.Models
{
    public class Consulta   
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid PatientId { get; set; }
        public Paciente? Paciente  { get; set; }
        public Guid? ProfessionalId { get; set; }
        public Medico? Medico { get; set; }
        public Guid? UnitId { get; set; }
        public Unit? Unit { get; set; }

        public string Type { get; set; } = "presential"; // presential|telemedicine|exam
        public string Status { get; set; } = "scheduled";
        public DateTime ScheduledAt { get; set; } = DateTime.UtcNow.AddDays(1);
        public int DurationMinutes { get; set; } = 30;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
