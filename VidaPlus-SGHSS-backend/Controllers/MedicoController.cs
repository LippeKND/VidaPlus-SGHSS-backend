using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VidaPlus_SGHSS_backend.Data;
using VidaPlus_SGHSS_backend.Models;

namespace SGHSS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicoController : ControllerBase
    {
        private readonly AppDbContext _db;
        public MedicoController(AppDbContext db) { _db = db; }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll() => Ok(await _db.Medicos.ToListAsync());

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> Get(Guid id)
        {
            var p = await _db.Medicos.FindAsync(id);
            if (p == null) return NotFound();
            return Ok(p);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] Medico medico)
        {
            _db.Medicos.Add(medico);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = medico.Id }, medico);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Medico update)
        {
            var p = await _db.Medicos.FindAsync(id);
            if (p == null) return NotFound();
            p.FullName = update.FullName;
            p.Specialty = update.Specialty;
            p.RegistrationNumber = update.RegistrationNumber;
            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var p = await _db.Medicos.FindAsync(id);
            if (p == null) return NotFound();
            _db.Medicos.Remove(p);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
