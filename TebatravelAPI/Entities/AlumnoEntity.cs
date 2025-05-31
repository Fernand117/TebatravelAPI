using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TebatravelAPI.Entities
{
    public class AlumnoEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AlumnoId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Paterno { get; set; } = string.Empty;
        public string Materno { get; set; } = string.Empty;
        public string NumCelular { get; set; } = string.Empty;
        public DateTime FechaNacimiento { get; set; }
        public string Correo { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public int CarreraId { get; set; }
        public int EscuelaId { get; set; }

        [ForeignKey("CarreraId")]
        public CarreraEntity Carrera { get; set; }

        [ForeignKey("EscuelaId")]
        public EscuelaEntity Escuela { get; set; }
    }
}
