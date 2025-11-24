using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VidaPlus_SGHSS_backend.Data;
using VidaPlus_SGHSS_backend.Models;

namespace VidaPlus_SGHSS_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConsultasController : ControllerBase
    {
        private readonly AppDbContext _db;
        public ConsultasController(AppDbContext db) { _db = db; }

        [HttpGet]
        [Authorize(Roles = "Admin,Professional")]
        public async Task<IActionResult> GetAll() => Ok(await _db.Consultas.Include(a => a.Paciente).Include(a => a.Medico).ToListAsync());

        [HttpPost]
        [Authorize(Roles = "Admin,Professional")]
        public async Task<IActionResult> Create([FromBody] Consulta consulta)
        {
            // simple conflict check for professional
            if (consulta.ProfessionalId != null)
            {
                var conflict = await _db.Consultas.AnyAsync(a => a.ProfessionalId == consulta.ProfessionalId && a.ScheduledAt == consulta.ScheduledAt && a.Status == "scheduled");
                if (conflict) return Conflict("Professional has a conflict at that time.");
            }
            _db.Consultas.Add(consulta);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = consulta.Id }, consulta);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id) =>
            (await _db.Consultas.FindAsync(id)) is { } consulta
                ? Ok(consulta)
                : NotFound();

        [HttpPut("{id}/cancel")]
        [Authorize(Roles = "Admin,Professional")]
        public async Task<IActionResult> Cancel(Guid id)
        {
            var a = await _db.Consultas.FindAsync(id);
            if (a == null) return NotFound();

            a.Status = "cancelled";
            await _db.SaveChangesAsync();

            return NoContent();
        }


        [HttpPut("{id}/complete")]
        [Authorize(Roles = "Admin,Professional")]
        public async Task<IActionResult> Complete(Guid id)
        {
            var a = await _db.Consultas.FindAsync(id);
            if (a == null) return NotFound();
            a.Status = "completed";
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
