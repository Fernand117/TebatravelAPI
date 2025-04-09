using Microsoft.AspNetCore.Mvc;
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
                    Nombre = alumnoRegistroDTO.Nombre
                };

                await _context.AddAsync(alumno);
                await _context.SaveChangesAsync();
                await transaccion.CommitAsync();

                return Ok(new ApiResponse(200, "Registrado", alumno));
            }
        }
    }
}
