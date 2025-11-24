using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VidaPlus_SGHSS_backend.Data;

namespace SGHSS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LogsAuditoriaController : ControllerBase
    {
        private readonly AppDbContext _db;
        public LogsAuditoriaController(AppDbContext db) { _db = db; }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll() => Ok(await _db.LogsAuditorias.OrderByDescending(a => a.CreatedAt).Take(200).ToListAsync());
    }
}

