using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TebatravelAPI.Context;

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
    }
}
