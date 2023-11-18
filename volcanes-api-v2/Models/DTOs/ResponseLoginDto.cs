namespace volcanes_api_v2.Models.DTOs;

public class ResponseLoginDto
{
    public string Token { get; set; } = String.Empty;

    public bool Proceso { get; set; }
}