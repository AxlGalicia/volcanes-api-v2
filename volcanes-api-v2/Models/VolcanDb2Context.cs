using Microsoft.EntityFrameworkCore;
using volcanes_api_v2.Models.Entity;

namespace volcanes_api_v2.Models;

public partial class VolcanDb2Context : DbContext
{
    public VolcanDb2Context(DbContextOptions<VolcanDb2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Role>? Roles { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

    public virtual DbSet<Volcan>? Volcanes { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable(tb => tb.HasComment("Aqui estaran los roles que se manejan en la base de datos volcanes"));

            entity.Property(e => e.Id)
                .HasColumnType("tinyint(4)")
                .HasColumnName("id");
            entity.Property(e => e.RoleName)
                .HasMaxLength(15)
                .HasColumnName("roleName");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Usuario");

            entity.HasIndex(e => e.Roleid, "Usuario_Roles_id_fk");

            entity.Property(e => e.Id)
                .HasColumnType("smallint(6)")
                .HasColumnName("id");
            entity.Property(e => e.Password)
                .HasColumnType("blob")
                .HasColumnName("password");
            entity.Property(e => e.Roleid)
                .HasColumnType("tinyint(4)")
                .HasColumnName("roleid");
            entity.Property(e => e.SaltKey)
                .HasColumnType("blob")
                .HasColumnName("saltKey");
            entity.Property(e => e.Username)
                .HasMaxLength(20)
                .HasColumnName("username");
            entity.Property(e => e.FechaCreacion).HasColumnName("fecha_creacion");
            entity.Property(e => e.FechaLimite).HasColumnName("fecha_limite");

            entity.HasOne(d => d.Role).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.Roleid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Usuario_Roles_id_fk");
        });

        modelBuilder.Entity<Volcan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("volcan");

            entity.HasIndex(e => e.IdCreador, "volcan_Usuario_id_fk");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Altura).HasColumnName("altura");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.Ecosistema)
                .HasMaxLength(255)
                .HasColumnName("ecosistema");
            entity.Property(e => e.IdCreador)
                .HasColumnType("smallint(6)")
                .HasColumnName("idCreador");
            entity.Property(e => e.Imagen)
                .HasMaxLength(255)
                .HasColumnName("imagen");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("nombre");
            entity.Property(e => e.Ubicacion)
                .HasMaxLength(255)
                .HasColumnName("ubicacion");

            entity.HasOne(d => d.IdCreadorNavigation).WithMany(p => p.Volcans)
                .HasForeignKey(d => d.IdCreador)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("volcan_Usuario_id_fk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

     partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
