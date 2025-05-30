namespace TebatravelAPI.Entities
{
    public class AsistenciaEntity
    {
        public int Id { get; set; }
        public string FechaAsistencia { get; set; } = string.Empty;
        public int IdAlumno { get; set; }
        public int IdCarrera { get; set; }
    }
}
