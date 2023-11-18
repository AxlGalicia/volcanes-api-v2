using volcanes_api_v2.Models.Entity;

namespace volcanes_api_v2.Interfaces;

public interface IJwtService
{
    string JwtGenerate(Usuario usuario);
}