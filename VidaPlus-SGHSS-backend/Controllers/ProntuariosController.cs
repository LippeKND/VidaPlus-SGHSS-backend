using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VidaPlus_SGHSS_backend.Data;
using VidaPlus_SGHSS_backend.Models;

namespace SGHSS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProntuariosController : ControllerBase
    {
        private readonly AppDbContext _db;
        public ProntuariosController(AppDbContext db) { _db = db; }

        [HttpGet("{pacienteId}")]
        [Authorize(Roles = "Admin,Professional,Patient")]
        public async Task<IActionResult> GetByPatient(Guid pacienteId)
        {
            var records = await _db.Prontuairos.Where(m => m.PacienteId == pacienteId).ToListAsync();
            return Ok(records);
        }

        [HttpPost]
        [Authorize(Roles = "Professional")]
        public async Task<IActionResult> Create([FromBody] Prontuario mr)
        {
            _db.Prontuairos.Add(mr);
            await _db.SaveChangesAsync();
            _db.LogsAuditorias.Add(new LogsAuditoria{ UserId = Guid.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)!.Value), Action = "CreateMedicalRecord", ResourceType = "MedicalRecord", ResourceId = mr.Id.ToString() });
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetByPatient), new { patientId = mr.PacienteId }, mr);
        }
    }
}

