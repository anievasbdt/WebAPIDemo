using Microsoft.AspNetCore.Mvc;
using Infraestructura.Persistencia;
using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Endpoints
{
    [ApiController]
    [Route("[controller]")]
    public class PolizaHistoryController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PolizaHistoryController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet("{nBranch}/{nProduct}/{nPolicy}")]
        public async Task<ActionResult<IEnumerable<PolizaHistory>>> GetPoliza_History(int nBranch, int nProduct, int nPolicy)
        {
            var polizaHistory = await _context.Poliza_History
                .Include(p => p.Client)
                .Include(p => p.WayPay)
                .Include(p => p.NullReason)
                .Include(p => p.Usuario)
                .Include(p => p.Branch)
                .Include(p => p.Product)
                .Where(p => p.NBranch == nBranch && p.NProduct == nProduct && p.NPolicy == nPolicy)
                .ToListAsync();

            if (polizaHistory == null || !polizaHistory.Any())
            {
                return NotFound();
            }
            return polizaHistory;
        }
    }
}
