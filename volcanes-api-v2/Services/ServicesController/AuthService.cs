
using Microsoft.EntityFrameworkCore;
using volcanes_api_v2.Interfaces;
using volcanes_api_v2.Models;
using volcanes_api_v2.Models.DTOs;
using volcanes_api_v2.Models.Entity;

namespace volcanes_api_v2.Services.ServicesController;

public class AuthService : IAuthService
{
    private readonly VolcanDb2Context _context;

    private readonly IHashService _hashService;

    private readonly IJwtService _jwtService;
    
    public AuthService(VolcanDb2Context context, IHashService hashService, IJwtService jwtService)
    {
        _context = context;
        _hashService = hashService;
        _jwtService = jwtService;
    }

    public async Task RegistryUser(UsuarioDto request)
    {
        _hashService.CreatePasswordHash(request.Password,
            out byte[] passwordHash,
            out byte[] passwordSalt );

        var usuario = new Usuario()
        {
            Username = request.Username,
            Password = passwordHash,
            SaltKey = passwordSalt,
            Roleid = 2,
            FechaCreacion = DateTime.UtcNow,
            FechaLimite = DateTime.UtcNow.AddDays(1)
        };

        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();
    }

    public async Task<ResponseLoginDto> LoginUser(UsuarioDto request)
    {
        var usuarioDb = await _context.Usuarios
            .FirstOrDefaultAsync(x => x.Username == request.Username);

        if (usuarioDb == null)
            return new ResponseLoginDto() { Proceso = false };
            
        var passwordHash = usuarioDb.Password;
        var passwordSalt = usuarioDb.SaltKey;

        if (!_hashService.VerifyPasswordHash(request.Password,
                passwordHash,
                passwordSalt))
            return new ResponseLoginDto() { Proceso = false};
        
        var token = _jwtService.JwtGenerate(usuarioDb);

        return new ResponseLoginDto() { Token = token, Proceso = true};
    }
    
}