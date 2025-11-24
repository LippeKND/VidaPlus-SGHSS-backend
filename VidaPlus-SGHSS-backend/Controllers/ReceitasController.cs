using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VidaPlus_SGHSS_backend.Data;
using VidaPlus_SGHSS_backend.Models;

namespace SGHSS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrescriptionsController : ControllerBase
    {
        private readonly AppDbContext _db;
        public PrescriptionsController(AppDbContext db) { _db = db; }

        [HttpPost]
        [Authorize(Roles = "Medico")]
        public async Task<IActionResult> Create([FromBody] Receita receita)
        {
            _db.Receitas.Add(receita);
            await _db.SaveChangesAsync();
            return CreatedAtAction(null, new { id = receita.Id }, receita);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> Get(Guid id)
        {
            var receita = await _db.Receitas.FindAsync(id);
            if (receita == null) return NotFound();
            return Ok(receita);
        }
    }
}

