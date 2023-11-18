namespace volcanes_api_v2.Models.Entity;

public class Usuario
{
    public short Id { get; set; }

    public string Username { get; set; } = null!;

    public byte[] Password { get; set; } = null!;

    public byte[] SaltKey { get; set; } = null!;

    public sbyte Roleid { get; set; }
    
    public DateTime FechaLimite { get; set; }

    public DateTime FechaCreacion { get; set; }
    
    public virtual Role Role { get; set; } = null!;

    public virtual ICollection<Volcan> Volcans { get; set; } = new List<Volcan>();
}
