using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VidaPlus_SGHSS_backend.Data;
using VidaPlus_SGHSS_backend.Models;

namespace VidaPlus_SGHSS_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeitosController : ControllerBase
    {
        private readonly AppDbContext _db;
        public LeitosController(AppDbContext db) { _db = db; }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _db.Leitos.Include(b => b.Unidades).ToListAsync());

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] Leito leito)
        {
            _db.Leitos.Add(leito);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAll), new { id = leito.Id }, leito);
        }
    }
}
