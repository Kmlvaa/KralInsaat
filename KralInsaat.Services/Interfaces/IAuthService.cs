using KralInsaat.Common.DTOs.Auth;

namespace KralInsaat.Services.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponseDTO> LoginAsync(LoginRequestDTO model);
        Task RegisterAsync(RegisterRequestDTO model);
    }
}
