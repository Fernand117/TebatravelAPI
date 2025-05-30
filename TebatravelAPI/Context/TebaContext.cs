using Microsoft.EntityFrameworkCore;
using TebatravelAPI.Entities;

namespace TebatravelAPI.Context
{
    public class TebaContext : DbContext
    {
        public TebaContext(DbContextOptions<TebaContext> options) : base(options) { }
        
        public virtual DbSet<CarreraEntity> CarreraEntities { get; set; }
        public virtual DbSet<EscuelaEntity> EscuelaEntities { get; set; }
        public virtual DbSet<AlumnoEntity> AlumnoEntities { get; set; }
        public virtual DbSet<AsistenciaEntity> AsistenciaEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CarreraEntity>(entity =>
            {
                entity.HasKey(c => c.CarreraId).HasName("PK_CarreraId");
                entity.ToTable("Carrera");
                
                entity.Property(c => c.CarreraId).ValueGeneratedOnAdd().UseIdentityColumn();
            });

            modelBuilder.Entity<EscuelaEntity>(entity =>
            {
                entity.HasKey(e => e.EscuelaId).HasName("PK_EscuelaId");
                entity.ToTable("Escuela");
                
                entity.Property(e => e.EscuelaId).ValueGeneratedOnAdd().UseIdentityColumn();
            });

            modelBuilder.Entity<AlumnoEntity>(entity =>
            {
                entity.HasKey(a => a.AlummnoId).HasName("PK_AlumnoId");
                entity.ToTable("Alumno");
                
                entity.Property(a => a.AlummnoId).ValueGeneratedOnAdd().UseIdentityColumn();
            });
            
            modelBuilder.Entity<AsistenciaEntity>(entity =>
            {
                entity.HasKey(a => a.Id).HasName("PK_AsistenciaId");
                entity.ToTable("Asistencia");
                
                entity.Property(a => a.Id).ValueGeneratedOnAdd().UseIdentityColumn();
            });
        }
    }
}
