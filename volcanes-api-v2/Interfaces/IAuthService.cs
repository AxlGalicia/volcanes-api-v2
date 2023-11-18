using volcanes_api_v2.Models.DTOs;

namespace volcanes_api_v2.Interfaces;

public interface IAuthService
{
    Task RegistryUser(UsuarioDto request);

    Task<ResponseLoginDto> LoginUser(UsuarioDto request);
}