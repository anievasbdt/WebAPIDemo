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
    public class BranchContrroller : ControllerBase
    {
        
        private readonly AppDbContext _context;

        public BranchContrroller(AppDbContext context)
        {
            _context = context;
        }

        // GET /Table10
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Branch>>> GetTable10()
        {
            return await _context.Table10.Include(b => b.Usuario).ToListAsync();
        }
    }
}
