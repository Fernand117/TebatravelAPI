namespace TebatravelAPI.Entities
{
    public class AlumnoEntity
    {
        public int AlummnoId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Paterno { get; set; } = string.Empty;
        public string Materno { get; set; } = string.Empty;
        public string NumCelular { get; set; } = string.Empty;
        public DateTime FechaNacimiento { get; set; }
        public string Correo { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public int CarreraId { get; set; }
        public int EscuelaId { get; set; }

        public CarreraEntity Carrera { get; set; }
        public EscuelaEntity Escuela { get; set; }

    }
}
