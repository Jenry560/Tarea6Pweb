
using Microsoft.EntityFrameworkCore;

namespace Tarea6Pweb.Models;

public partial class PruebaDbContext : DbContext
{
    public PruebaDbContext()
    {
    }

    public PruebaDbContext(DbContextOptions<PruebaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Agente> Agentes { get; set; }

    public virtual DbSet<Incidencia> Incidencias { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Agente>(entity =>
        {
            entity.HasKey(e => e.AgenteId).HasName("PK__Agentes__EA09D85D4471E64A");

            entity.HasIndex(e => e.Cedula, "UQ__Agentes__B4ADFE38AC221594").IsUnique();

            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Cedula)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.ClaveAgente)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Incidencia>(entity =>
        {
            entity.HasKey(e => e.IncidenciaId).HasName("PK__Incidenc__E41133E63DBE358E");

            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Latitud).HasColumnType("decimal(10, 8)");
            entity.Property(e => e.Longitud).HasColumnType("decimal(11, 8)");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Pasaporte)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.WhatsApp)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.CodigoAgenteNavigation).WithMany(p => p.Incidencia)
                .HasForeignKey(d => d.CodigoAgente)
                .HasConstraintName("FK__Incidenci__Codig__571DF1D5");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
