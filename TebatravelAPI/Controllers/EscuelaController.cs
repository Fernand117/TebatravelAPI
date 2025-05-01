using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TebatravelAPI.Context;

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
    }
}
