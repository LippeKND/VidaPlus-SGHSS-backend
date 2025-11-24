using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VidaPlus_SGHSS_backend.Data;
using VidaPlus_SGHSS_backend.Models;

namespace SGHSS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UnidadeController : ControllerBase
    {
        private readonly AppDbContext _db;
        public UnidadeController(AppDbContext db) { _db = db; }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _db.Unidade.ToListAsync());

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] Unidade unidade)
        {
            _db.Unidade.Add(unidade);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAll), new { id = unidade.Id }, unidade);
        }
    }
}
