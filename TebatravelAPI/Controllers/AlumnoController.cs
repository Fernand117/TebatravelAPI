using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TebatravelAPI.Context;
using TebatravelAPI.DTO;
using TebatravelAPI.Entities;

namespace TebatravelAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlumnoController : ControllerBase
    {
        private readonly TebaContext _context;

        public AlumnoController(TebaContext context) { _context = context; }

        [HttpPost]
        public async Task<ActionResult> RegistroAlumno([FromBody] AlumnoRegistroDTO alumnoRegistroDTO)
        {
            await using (var transaccion = await _context.Database.BeginTransactionAsync())
            {
                var alumno = new AlumnoEntity()
                {
                    Nombre = alumnoRegistroDTO.Nombre,
                    Paterno = alumnoRegistroDTO.Paterno,
                    Materno = alumnoRegistroDTO.Materno,
                    NumCelular = alumnoRegistroDTO.NumCelular,
                    FechaNacimiento = alumnoRegistroDTO.FechaNacimiento,
                    Correo = alumnoRegistroDTO.Correo,
                    Password = alumnoRegistroDTO.Password,
                    CarreraId = alumnoRegistroDTO.CarreraId,
                    EscuelaId = alumnoRegistroDTO.EscuelaId
                };

                await _context.AddAsync(alumno);
                await _context.SaveChangesAsync();
                await transaccion.CommitAsync();

                return Ok(new ApiResponse(200, "Registrado", alumno));
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> EditarAlumno(int id, [FromBody] AlumnoRegistroDTO alumnoDTO)
        {
            var alumno = await _context.AlumnoEntities.FindAsync(id);
            if (alumno == null) return NotFound(new ApiResponse(404, "Alumno no encontrado"));

            alumno.Nombre = alumnoDTO.Nombre;
            alumno.Paterno = alumnoDTO.Paterno;
            alumno.Materno = alumnoDTO.Materno;
            alumno.NumCelular = alumnoDTO.NumCelular;
            alumno.FechaNacimiento = alumnoDTO.FechaNacimiento;
            alumno.Correo = alumnoDTO.Correo;
            alumno.Password = alumnoDTO.Password;
            alumno.CarreraId = alumnoDTO.CarreraId;
            alumno.EscuelaId = alumnoDTO.EscuelaId;

            _context.Update(alumno);
            await _context.SaveChangesAsync();
            return Ok(new ApiResponse(200, "Actualizado", alumno));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> ObtenerAlumno(int id)
        {
            var alumno = await _context.AlumnoEntities.FindAsync(id);
            if (alumno == null) return NotFound(new ApiResponse(404, "Alumno no encontrado"));
            
            return Ok(new ApiResponse(200, "Encontrado", alumno));
        }

        [HttpGet]
        public async Task<ActionResult> ListarAlumnos()
        {
            var alumnos = await _context.AlumnoEntities.ToListAsync();
            return Ok(new ApiResponse(200, "Lista de alumnos", alumnos));
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            var alumno = await _context.AlumnoEntities
                .FirstOrDefaultAsync(x => x.Correo == loginDTO.Correo && x.Password == loginDTO.Password);

            if (alumno == null) return Unauthorized(new ApiResponse(401, "Credenciales inválidas"));
            
            return Ok(new ApiResponse(200, "Login exitoso", alumno));
        }
    }
}
