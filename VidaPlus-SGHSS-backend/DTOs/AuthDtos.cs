namespace VidaPlus_SGHSS_backend.DTos;

public record RegisterDto(string Email, string Senha, string Role); // Papel: Admin|Medico|Paciente
public record LoginDto(string Email, string Senha);
public record AuthResult(string AccessToken);
