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
    public class NMPolizaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public NMPolizaController(AppDbContext context)
        {
            _context = context;
        }

        // GET /Table13
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NMPoliza>>> GetTable13()
        {
            return await _context.Table13.Include(n => n.Usuario).ToListAsync();
        }
    }
}
