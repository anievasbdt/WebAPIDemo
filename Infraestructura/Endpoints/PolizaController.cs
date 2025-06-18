using Dominio.Entidades;
using Infraestructura.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Endpoints
{
    [ApiController]
    [Route("[controller]")]
    public  class PolizaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PolizaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("{nBranch}/{nProduct}/{nPolicy}")]
        public async Task<ActionResult<Poliza>> GetPoliza(int nBranch, int nProduct, int nPolicy)
        {
            var poliza = await _context.Poliza
                .Include(p => p.Client) 
                .Include(p => p.WayPay)
                .Include(p => p.NullCode)
                .Include(p => p.Usuario)
                .Include(p => p.Product)
                .FirstOrDefaultAsync(p => p.NBranch == nBranch && p.NProduct == nProduct && p.NPolicy == nPolicy);

            if (poliza == null)
            {
                return NotFound();
            }
            return poliza;
        }

        [HttpGet("{sclient}")]
        public async Task<ActionResult<IEnumerable<Poliza>>> GetPolizasBySClient(string sclient)
        {
            var polizas = await _context.Poliza
                .Include(p => p.Client)
                .Include(p => p.WayPay)
                .Include(p => p.NullCode)
                .Include(p => p.Usuario)
                .Include(p => p.Product)
                .Where(p => p.Client.SClient == sclient) // Filtra por SClient
                .ToListAsync();

            if (polizas == null || !polizas.Any())
            {
                return NotFound();
            }
            return polizas;
        }
    }
}
