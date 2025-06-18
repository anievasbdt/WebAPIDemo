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
    public class Way_payController : ControllerBase
    {
        private readonly AppDbContext _context;

        public Way_payController(AppDbContext context)
        {
            _context = context;
        }

        // GET /Table5002
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Way_pay>>> GetTable5002()
        {
            return await _context.Table5002.Include(w => w.Usuario).ToListAsync();
        }
    }
}
