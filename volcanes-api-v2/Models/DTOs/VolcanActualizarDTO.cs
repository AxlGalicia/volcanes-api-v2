namespace volcanes_api_v2.Models.DTOs;

public class VolcanActualizarDTO
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public float Altura { get; set; }
    public string Ubicacion { get; set; }
    public string Ecosistema { get; set; }
}