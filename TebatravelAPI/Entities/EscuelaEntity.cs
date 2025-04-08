namespace TebatravelAPI.Entities
{
    public class EscuelaEntity
    {
        public int EscuelaId { get; set; }
        public string NombreEscuela { get; set; } = string.Empty;
        public string Clave { get; set; } = string.Empty;
        public AlumnoEntity Alumno { get; set; } = new AlumnoEntity();
    }
}
