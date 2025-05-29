using Microsoft.AspNetCore.Mvc;
using TebatravelAPI.Context;
using TebatravelAPI.Entities;

namespace TebatravelAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AsistenciaController : ControllerBase
    {
        private readonly TebaContext _context;

        public AsistenciaController(TebaContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> RegistroAsistencia([FromBody] AsistenciaEntity asistencia)
        {
            await using (var transaccion = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    await _context.AsistenciaEntities.AddAsync(asistencia);
                    await _context.SaveChangesAsync();
                    await transaccion.CommitAsync();
                    return Ok(new { message = "Asistencia registrada correctamente.", asistencia });
                }
                catch (Exception ex)
                {
                    await transaccion.RollbackAsync();
                    return StatusCode(500, new { message = "Error al registrar la asistencia.", error = ex.Message });
                }
            }
        }
    }
}