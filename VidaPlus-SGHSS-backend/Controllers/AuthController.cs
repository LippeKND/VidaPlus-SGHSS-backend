using Microsoft.AspNetCore.Mvc;
using VidaPlus_SGHSS_backend.Data;
using VidaPlus_SGHSS_backend.DTos;
using VidaPlus_SGHSS_backend.Models;
using VidaPlus_SGHSS_backend.Service;

namespace VidaPlus_SGHSS_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly IAuthService _auth;
        public AuthController(AppDbContext db, IAuthService auth) { _db = db; _auth = auth; }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterDto dto)
        {
            if (_db.Usuarios.Any(u => u.Email == dto.Email)) return Conflict("Email already in use.");
            var papel = Enum.TryParse<UserRole>(dto.Role, true, out var r) ? r : UserRole.Paciente;
            var usuario = new Usuario { Email = dto.Email, Senha = BCrypt.Net.BCrypt.HashPassword(dto.Senha), Papel = papel };
            _db.Usuarios.Add(usuario);
            _db.SaveChanges();

            // create related entity
            if (papel == UserRole.Paciente) _db.Pacientes.Add(new Paciente { UserId = usuario.Id, FullName = "Paciente " + dto.Email });
            if (papel == UserRole.Medico) _db.Medicos.Add(new Medico { UserId = usuario.Id, FullName = "Medico " + dto.Email });
            _db.SaveChanges();

            return CreatedAtAction(null, new { id = usuario.Id });
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto dto)
        {
            var usuario = _db.Usuarios.FirstOrDefault(u => u.Email == dto.Email);
            if (usuario == null || !BCrypt.Net.BCrypt.Verify(dto.Senha, usuario.Senha)) return Unauthorized();

            var token = _auth.GenerateJwtToken(usuario);
            return Ok(new AuthResult(token));
        }
    }
}
