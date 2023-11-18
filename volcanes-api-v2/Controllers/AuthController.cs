using Microsoft.AspNetCore.Mvc;
using volcanes_api_v2.Interfaces;
using volcanes_api_v2.Models.DTOs;

namespace volcanes_api_v2.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    
    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }
    
    [HttpPost("register")]
    public async Task<ActionResult> Register(UsuarioDto request)
    {
        await _authService.RegistryUser(request);
        
        return Ok("Usuario creado, ahora puedes iniciar sesion");

    }
    
    [HttpPost("login")]
    public async Task<ActionResult> Login(UsuarioDto request)
    {

        var response = await _authService.LoginUser(request);

        if (!response.Proceso && response.Token == String.Empty)
            return BadRequest("El usuario o la contraseña son incorrectas");
       
        return Ok(response.Token);
    }
    
    
}