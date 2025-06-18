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
    public class ProductMasterController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductMasterController(AppDbContext context)
        {
            _context = context;
        }

        // GET /ProductMaster
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductMaster>>> GetProductMaster()
        {
            return await _context.ProductMaster.Include(p => p.Branch).Include(p => p.Usuario).ToListAsync();
        }
    }
}
