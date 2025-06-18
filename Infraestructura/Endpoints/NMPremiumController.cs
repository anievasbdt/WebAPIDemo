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
    public class NMPremiumController : ControllerBase
    {
        private readonly AppDbContext _context;

        public NMPremiumController(AppDbContext context)
        {
            _context = context;
        }

        // GET /Table95
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NMPremium>>> GetTable95()
        {
            return await _context.Table95.Include(n => n.Usuario).ToListAsync();
        }
    }
}
