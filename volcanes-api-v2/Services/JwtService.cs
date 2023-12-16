using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using volcanes_api_v2.Interfaces;
using volcanes_api_v2.Models.Entity;

namespace volcanes_api_v2.Services;

public class JwtService : IJwtService
{
    private readonly IConfiguration _configuration;
    
    public JwtService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string JwtGenerate(Usuario usuario)
    {
        List<Claim> claims;
        
        if (usuario.Roleid == 1)
        {
            
            claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,usuario.Username),
                new Claim(ClaimTypes.Role,"admin")
            };
        }
        else
        {
            claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,usuario.Username),
                new Claim(ClaimTypes.Role,"user")
            };
        }
        
        var keyJwt= _configuration["JwtKey"];
        if (keyJwt is null)
            throw new NullReferenceException("La llava jwt no se encuentra");
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyJwt));

        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(2),
            signingCredentials:credentials
        );

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);
        
        return jwt;
    }
}