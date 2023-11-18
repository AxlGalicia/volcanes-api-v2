using System.ComponentModel.DataAnnotations;

namespace volcanes_api_v2.Models.DTOs;
public class UsuarioDto
{
    [Required(ErrorMessage = "El campo username es obligatorio")]
    [StringLength(maximumLength:20,MinimumLength= 2,ErrorMessage = "El tamaño del username de estar entre 2 a 20 caracteres")]
    public string Username { get; set; } = String.Empty;
    
    [Required(ErrorMessage = "El campo password es obligatorio")]
    [StringLength(maximumLength:20,MinimumLength= 8,ErrorMessage = "El tama;o del password de estar entre 1 a 20 caracteres")]
    public string Password { get; set; } = String.Empty;
}