using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VidaPlus_SGHSS_backend.Data;
using VidaPlus_SGHSS_backend.Models;

namespace VidaPlus_SGHSS_backend.Controllers
{
    [ApiController]
    [Route("api/pacientes")]
    public class PacientesController : ControllerBase
    {
        private readonly AppDbContext _db;

        public PacientesController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _db.Pacientes.ToListAsync());
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] Paciente paciente)
        {
            paciente.Id = Guid.NewGuid();
            _db.Pacientes.Add(paciente);
            await _db.SaveChangesAsync();
            return Ok(paciente);
        }
    }
}
