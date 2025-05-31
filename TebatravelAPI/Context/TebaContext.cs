using Microsoft.EntityFrameworkCore;
using TebatravelAPI.Entities;

namespace TebatravelAPI.Context
{
    public class TebaContext : DbContext
    {
        public TebaContext(DbContextOptions<TebaContext> options) : base(options) { }

        public virtual DbSet<CarreraEntity> Carreras { get; set; }
        public virtual DbSet<EscuelaEntity> Escuelas { get; set; }
        public virtual DbSet<AlumnoEntity> Alumnos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CarreraEntity>(entity =>
            {
                entity.HasKey(c => c.CarreraId).HasName("PK_CarreraId");
                entity.ToTable("Carrera");

                entity.Property(c => c.CarreraId).ValueGeneratedOnAdd().UseIdentityByDefaultColumn();
            });

            modelBuilder.Entity<EscuelaEntity>(entity =>
            {
                entity.HasKey(e => e.EscuelaId).HasName("PK_EscuelaId");
                entity.ToTable("Escuela");

                entity.Property(e => e.EscuelaId).ValueGeneratedOnAdd().UseIdentityByDefaultColumn();
            });

            modelBuilder.Entity<AlumnoEntity>(entity =>
            {
                entity.HasKey(a => a.AlumnoId).HasName("PK_AlumnoId");
                entity.ToTable("Alumno");

                entity.Property(a => a.AlumnoId).ValueGeneratedOnAdd().UseIdentityByDefaultColumn();

                // Configurar las relaciones sin índices únicos
                entity.HasOne(a => a.Carrera)
                    .WithMany()
                    .HasForeignKey(a => a.CarreraId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(a => a.Escuela)
                    .WithMany()
                    .HasForeignKey(a => a.EscuelaId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
