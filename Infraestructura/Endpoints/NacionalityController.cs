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
    public class NacionalityController : ControllerBase
    {
        private readonly AppDbContext _context;

        public NacionalityController(AppDbContext context)
        {
            _context = context;
        }

        // GET /Table5518
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Nacionality>>> GetTable5518()
        {
            return await _context.Table5518.Include(n => n.Usuario).ToListAsync();
        }
    }
}
