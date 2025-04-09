using Microsoft.EntityFrameworkCore;
using TebatravelAPI.Entities;

namespace TebatravelAPI.Context
{
    public class TebaContext : DbContext
    {
        public TebaContext(DbContextOptions<TebaContext> options) : base(options) { }
        
        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured) optionsBuilder.UseNpgsql("host=localhost;port=5432;database=tebaDB;username=postgres;password=Master117+");
        }*/

        public virtual DbSet<CarreraEntity> CarreraEntities { get; set; }
        public virtual DbSet<EscuelaEntity> EscuelaEntities { get; set; }
        public virtual DbSet<AlumnoEntity> AlumnoEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CarreraEntity>(entity =>
            {
                entity.HasKey(c => c.CarreraId).HasName("PK_CarreraId");
                entity.ToTable("Carrera");
            });

            modelBuilder.Entity<EscuelaEntity>(entity =>
            {
                entity.HasKey(e => e.EscuelaId).HasName("PK_EscuelaId");
                entity.ToTable("Escuela");
            });

            modelBuilder.Entity<AlumnoEntity>(entity =>
            {
                entity.HasKey(a => a.AlummnoId).HasName("PK_AlumnoId");
                entity.ToTable("Alumno");
            });
        }
    }
}
