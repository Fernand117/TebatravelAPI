namespace TebatravelAPI.Entities
{
    public class CarreraEntity
    {
        public int CarreraId { get; set; }
        public string NombreCarrera { get; set; } = string.Empty;
        public AlumnoEntity Alumno { get; set; }
    }
}
