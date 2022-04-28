using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PruebaWTW.DataAccess.Models
{
    public partial class PruebaWTWContext : DbContext
    {
        public PruebaWTWContext()
        {
        }

        public PruebaWTWContext(DbContextOptions<PruebaWTWContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Persona> Personas { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Creacion")
                    .HasComputedColumnSql("(getdate())", false);

                entity.Property(e => e.IdentificacionTipo)
                    .IsRequired()
                    .HasMaxLength(151)
                    .IsUnicode(false)
                    .HasColumnName("Identificacion_Tipo")
                    .HasComputedColumnSql("(([Numero_Identificacion]+'-')+[Tipo_Identificacion])", false);

                entity.Property(e => e.NombreCompleto)
                    .IsRequired()
                    .HasMaxLength(101)
                    .IsUnicode(false)
                    .HasColumnName("Nombre_Completo")
                    .HasComputedColumnSql("(([Nombres]+'-')+[Apellidos])", false);

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroIdentificacion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Numero_Identificacion");

                entity.Property(e => e.TipoIdentificacion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Tipo_Identificacion");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Creacion")
                    .HasComputedColumnSql("(getdate())", false);

                entity.Property(e => e.NombreUsuario)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nombre_Usuario");

                entity.Property(e => e.Pass)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
