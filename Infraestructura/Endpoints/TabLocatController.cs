using Microsoft.AspNetCore.Mvc;
using Infraestructura.Persistencia;
using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infraestructura.Endpoints
{
    [ApiController]
    [Route("[controller]")]
    public class TabLocatController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TabLocatController(AppDbContext context)
        {
            _context = context;
        }

        // GET /Tab_Locat
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TabLocat>>> GetTab_Locat()
        {
            return await _context.Tab_Locat.Include(t => t.Municipality).ThenInclude(m => m.Province).ThenInclude(p => p.Usuario) // Carga la entidad Usuario
                .Include(t => t.Usuario).ToListAsync();
        }
    }
}
