using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VidaPlus_SGHSS_backend.Data;
using VidaPlus_SGHSS_backend.DTos;
using VidaPlus_SGHSS_backend.Models;
using VidaPlus_SGHSS_backend.Services;

namespace VidaPlus_SGHSS_backend.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly JwtService _jwt;

        public AuthController(AppDbContext db, JwtService jwt)
        {
            _db = db;
            _jwt = jwt;
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthResult>> Login(LoginDto dto)
        {
            var user = await _db.Usuarios
                .FirstOrDefaultAsync(u => u.Email == dto.Email);

            if (user == null)
                return Unauthorized("Email inválido");

            if (!BCrypt.Net.BCrypt.Verify(dto.Senha, user.Senha))
                return Unauthorized("Senha inválida");

            var token = _jwt.GenerateToken(user.Email, user.Role);

            return Ok(new AuthResult(token));
        }
    }
}
