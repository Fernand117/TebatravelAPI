using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TebatravelAPI.Context;
using TebatravelAPI.Entities;

namespace TebatravelAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarreraController : ControllerBase
    {
        private readonly TebaContext _context;

        public CarreraController(TebaContext context) { _context = context; }

        [HttpGet]
        public async Task<ActionResult> ListaCarreras()
        {
            var carreras = await _context.CarreraEntities.ToListAsync();
            return Ok(new ApiResponse(200, "Lista de carreras", carreras));
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult> ObtenerCarrera(int id)
        {
            var carrera = await _context.CarreraEntities.FindAsync(id);
            if (carrera == null) return NotFound(new ApiResponse(404, "Carrera no encontrada"));
            
            return Ok(new ApiResponse(200, "Encontrado", carrera));
        }

        [HttpPost]
        public async Task<ActionResult> GuardarCarrera([FromBody] CarreraEntity carrera)
        {
            var carreraExistente = await _context.CarreraEntities.FirstOrDefaultAsync(x => x.NombreCarrera == carrera.NombreCarrera);
            
            if (carreraExistente != null) return BadRequest(new ApiResponse(400, "Carrera ya existe"));
            
            await _context.AddAsync(carrera);
            await _context.SaveChangesAsync();
            
            return Ok(new ApiResponse(200, "Carrera guardada", carrera) );;
        }
    }
}
