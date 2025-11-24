using VidaPlus_SGHSS_backend.Models;

namespace VidaPlus_SGHSS_backend.Service
{
    public interface IAuthService
    {
        string GenerateJwtToken(Usuario usuario);
    }
}
