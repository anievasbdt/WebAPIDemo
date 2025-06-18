using Microsoft.AspNetCore.Mvc;
using Infraestructura.Persistencia;
using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Infraestructura.Endpoints
{
    [ApiController]
    [Route("[controller]")]
    public class SexController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SexController(AppDbContext context)
        {
            _context = context;
        }

        // GET /Table18
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sex>>> GetTable18()
        {
            return await _context.Table18
                .Include(s => s.Usuario) // Incluye la entidad relacionada
                .ToListAsync();
        }
    }
}
