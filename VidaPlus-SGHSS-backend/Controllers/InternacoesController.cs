using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VidaPlus_SGHSS_backend.Data;
using VidaPlus_SGHSS_backend.Models;

namespace VidaPlus_SGHSS_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class internacoesController : ControllerBase
    {
        private readonly AppDbContext _db;
        public internacoesController(AppDbContext db) { _db = db; }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Admit([FromBody] Internacao internacao)
        {
            var bed = await _db.Leitos.FindAsync(internacao.LeitoId);
            if (bed == null || bed.Status != "free") return BadRequest("Bed not available.");
            bed.Status = "occupied";
            _db.Internacaos.Add(internacao);
            await _db.SaveChangesAsync();
            return CreatedAtAction(null, new { id = internacao.Id }, internacao);
        }

        [HttpPut("{id}/discharge")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Discharge(Guid id)
        {
            var adm = await _db.Internacaos.Include(a => a.Leito).FirstOrDefaultAsync(a => a.Id == id);
            if (adm == null) return NotFound();
            adm.DischargedAt = DateTime.UtcNow;
            if (adm.Leito != null) adm.Leito.Status = "free";
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
