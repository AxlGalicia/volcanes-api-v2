namespace volcanes_api_v2.Models.Entity;

/// <summary>
/// Aqui estaran los roles que se manejan en la base de datos volcanes
/// </summary>
public class Role
{
    public sbyte Id { get; set; }

    public string RoleName { get; set; } = null!;

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
