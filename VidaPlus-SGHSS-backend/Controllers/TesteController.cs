using Microsoft.AspNetCore.Mvc;
using VidaPlus_SGHSS_backend.Data;
using System.Linq;

namespace SGHSS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly AppDbContext _db;
        public TestController(AppDbContext db) { _db = db; }

        [HttpGet("health")]
        public IActionResult Health() => Ok(new { status = "ok" });

        [HttpGet("patients")]
        public IActionResult Patients() => Ok(_db.Pacientes.Select(p => new { p.Id, p.FullName }).ToList());
    }
}
