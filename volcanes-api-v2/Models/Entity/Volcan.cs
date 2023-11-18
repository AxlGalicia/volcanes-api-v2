namespace volcanes_api_v2.Models.Entity;
public class Volcan
{
    public int Id { get; set; }

    public string Nombre { get; set; } = String.Empty;

    public string Descripcion { get; set; } = String.Empty;

    public double Altura { get; set; }

    public string Ubicacion { get; set; } = String.Empty;

    public string Ecosistema { get; set; } = String.Empty;

    public string Imagen { get; set; } = String.Empty;

    public short IdCreador { get; set; }
    
    public virtual Usuario IdCreadorNavigation { get; set; } = null!;
}
