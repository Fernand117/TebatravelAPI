using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TebatravelAPI.Context;
using TebatravelAPI.Entities;

namespace TebatravelAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EscuelaController : Controller
    {
        private readonly TebaContext _context;
        
        public EscuelaController(TebaContext context) { _context = context; }

        [HttpGet]
        public async Task<ActionResult> ListEscuelas()
        {
            var escuelas = await _context.EscuelaEntities.ToListAsync();

            return Ok(new ApiResponse(200, "Lista de escuelas", escuelas));
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult> ObtenerEscuela(int id)
        {
            var escuela = await _context.EscuelaEntities.FindAsync(id);
            if (escuela == null) return NotFound(new ApiResponse(404, "Escuela no encontrada"));
            
            return Ok(new ApiResponse(200, "Encontrado", escuela));
        }

        [HttpPost]
        public async Task<ActionResult> GuardarEscuela([FromBody] EscuelaEntity escuela)
        {
            var escuelaExiste = await _context.EscuelaEntities.FirstOrDefaultAsync(e => e.NombreEscuela == escuela.NombreEscuela);
            if (escuelaExiste != null) return BadRequest(new ApiResponse(400, "Escuela ya existe"));
            
            await _context.AddAsync(escuela);
            await _context.SaveChangesAsync();
            
            return Ok(new ApiResponse(200, "Escuela guardada", escuela) );;
        }
    }
}
