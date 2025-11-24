using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts;
using VidaPlus_SGHSS_backend.Data;
using VidaPlus_SGHSS_backend.Models;

namespace SGHSS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacientesController : ControllerBase
    {
        private readonly AppDbContext _db;
        public PacientesController(AppDbContext db) { _db = db; }

        [HttpGet]
        [Authorize(Roles = "Admin,Professional")]
        public async Task<IActionResult> GetAll() => Ok(await _db.Pacientes.ToListAsync());

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> Get(Guid id)
        {
            var p = await _db.Pacientes.FindAsync(id);
            if (p == null) return NotFound();
            return Ok(p);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] Paciente paciente)
        {
            _db.Pacientes.Add(paciente);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = paciente.Id }, paciente);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Professional")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Paciente update)
        {
            var p = await _db.Pacientes.FindAsync(id);
            if (p == null) return NotFound();
            p.FullName = update.FullName;
            p.Phone = update.Phone;
            p.Address = update.Address;
            p.ConsentLgpd = update.ConsentLgpd;
            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var p = await _db.Pacientes.FindAsync(id);
            if (p == null) return NotFound();
            _db.Pacientes.Remove(p);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}

